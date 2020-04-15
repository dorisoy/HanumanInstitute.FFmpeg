﻿using System;
using System.Globalization;
using HanumanInstitute.Encoder.Properties;

namespace HanumanInstitute.Encoder
{
    /// <summary>
    /// Provides functions to get information on media files.
    /// </summary>
    public class MediaInfoReader : IMediaInfoReader
    {
        private readonly IProcessWorkerFactory factory;

        public MediaInfoReader(IProcessWorkerFactory processFactory)
        {
            factory = processFactory ?? throw new ArgumentNullException(nameof(processFactory));
        }

        /// <summary>
        /// Returns the version information from FFmpeg.
        /// </summary>
        /// <param name="options">The options for starting the process.</param>
        /// <param name="callback">A method that will be called after the process has been started.</param>
        /// <returns>A IFFmpegProcess object containing the version information.</returns>
        public string GetVersion(ProcessOptionsEncoder options = null, ProcessStartedEventHandler callback = null)
        {
            IProcessWorkerEncoder Worker = factory.CreateEncoder(options, callback);
            Worker.OutputType = ProcessOutput.Output;
            Worker.RunEncoder("-version", EncoderApp.FFmpeg);
            return Worker.Output;
        }

        /// <summary>
        /// Gets file streams information of specified file via FFmpeg.
        /// </summary>
        /// <param name="source">The file to get information about.</param>
        /// <param name="options">The options for starting the process.</param>
        /// <param name="callback">A method that will be called after the process has been started.</param>
        /// <returns>A IFFmpegProcess object containing the file information.</returns>
        public IFileInfoFFmpeg GetFileInfo(string source, ProcessOptionsEncoder options = null, ProcessStartedEventHandler callback = null)
        {
            ArgHelper.ValidateNotNullOrEmpty(source, nameof(source));

            IProcessWorkerEncoder Worker = factory.CreateEncoder(options, callback);
            Worker.ProcessCompleted += (s, e) =>
            {
                if (e.Status == CompletionStatus.Failed && (Worker.FileInfo as IFileInfoFFmpeg)?.FileStreams != null)
                {
                    e.Status = CompletionStatus.Success;
                }
            };
            Worker.RunEncoder($@"-i ""{source}""", EncoderApp.FFmpeg);
            return Worker.FileInfo as IFileInfoFFmpeg;
        }

        /// <summary>
        /// Returns the exact frame count of specified video file.
        /// </summary>
        /// <param name="source">The file to get information about.</param>
        /// <param name="options">The options for starting the process.</param>
        /// <param name="callback">A method that will be called after the process has been started.</param>
        /// <returns>The number of frames in the video.</returns>
        public long GetFrameCount(string source, ProcessOptionsEncoder options = null, ProcessStartedEventHandler callback = null)
        {
            ArgHelper.ValidateNotNullOrEmpty(source, nameof(source));

            long Result = 0;
            IProcessWorkerEncoder Worker = factory.CreateEncoder(options, callback);
            Worker.ProgressReceived += (sender, e) =>
            {
                // Read all status lines and keep the last one.
                Result = (e.Progress as ProgressStatusFFmpeg).Frame;
            };
            Worker.RunEncoder($@"-i ""{source}"" -f null /dev/null", EncoderApp.FFmpeg);
            return Result;
        }
    }
}
