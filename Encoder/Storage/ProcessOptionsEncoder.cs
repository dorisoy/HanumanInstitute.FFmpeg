﻿using System;
using System.Diagnostics;

namespace HanumanInstitute.Encoder
{
    /// <summary>
    /// Contains options to control the behaviors of an encoder process.
    /// </summary>
    public class ProcessOptionsEncoder : ProcessOptions
    {
        /// <summary>
        /// Gets or sets the frame count to use when it is not automatically provided by the input file.
        /// </summary>
        public long FrameCount { get; set; }
        /// <summary>
        /// When running several tasks at once, gets or sets the amount of frames for the entire job. If 0, it will be calculated using FrameCount and ResumePos.
        /// </summary>
        public long TotalFrameCount { get; set; }
        /// <summary>
        /// If resuming a job, gets or sets the number of frames that were done previously.
        /// </summary>
        public long ResumePos { get; set; }

        /// <summary>
        /// Initializes a new instance of the ProcessOptionsEncode class.
        /// </summary>
        public ProcessOptionsEncoder() { }

        /// <summary>
        /// Initializes a new instance of the ProcessOptionsEncode class.
        /// </summary>
        /// <param name="displayMode">Gets or sets the display mode when running FFmpeg.</param>
        public ProcessOptionsEncoder(ProcessDisplayMode displayMode) : base(displayMode) { }

        /// <summary>
        /// Initializes a new instance of the ProcessOptionsEncode class.
        /// </summary>
        /// <param name="displayMode">Gets or sets the display mode when running FFmpeg.</param>
        /// <param name="title">The title to display.</param>
        public ProcessOptionsEncoder(ProcessDisplayMode displayMode, string title) : base(displayMode, title) { }

        /// <summary>
        /// Initializes a new instance of the ProcessOptionsEncode class.
        /// </summary>
        /// <param name="displayMode">The display mode when running FFmpeg.</param>
        /// <param name="title">The title to display..</param>
        /// <param name="priority">The overall priority category for the associated process.</param>
        public ProcessOptionsEncoder(ProcessDisplayMode displayMode, string title, ProcessPriorityClass priority) : base(displayMode, title, priority) { }

        /// <summary>
        /// Initializes a new instance of the ProcessOptionsEncode class to display several jobs in the same UI.
        /// </summary>
        /// <param name="jobId">An identifier for the job. Can be used to link a set of jobs to the same UI.</param>
        /// <param name="title">The title to display.</param>
        /// <param name="isMainTask">When displaying several tasks in the same UI, whether this is the main task.</param>
        public ProcessOptionsEncoder(object jobId, string title, bool isMainTask) : base(jobId, title, isMainTask) { }
    }
}
