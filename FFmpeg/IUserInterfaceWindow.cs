﻿using System;

namespace HanumanInstitute.FFmpeg {
    /// <summary>
    /// Provides an interface that must be implemented by the FFmpeg graphical interface window.
    /// </summary>
    public interface IUserInterfaceWindow {
        /// <summary>
        /// Closes the window.
        /// </summary>
        void Close();
        /// <summary>
        /// Displays specified process.
        /// </summary>
        /// <param name="host">The process to display.</param>
        void DisplayTask(IProcessWorker host);
    }
}
