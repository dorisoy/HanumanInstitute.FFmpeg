﻿using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32.SafeHandles;
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global

namespace HanumanInstitute.FFmpeg.Services;

/// <inheritdoc cref="IProcess"/>
public class ProcessWrapper : IProcess, IDisposable
{
    private readonly Process _process;

    /// <summary>
    /// Initializes a new instance of the ProcessWrapper class for a new process.
    /// </summary>
    public ProcessWrapper()
    {
        _process = new Process();
    }

    /// <summary>
    /// Initializes a new instance of the ProcessWrapper class for specified process.
    /// </summary>
    public ProcessWrapper(Process? process)
    {
        _process = process ?? new Process();
    }

    /// <inheritdoc />
    public ProcessPriorityClass PriorityClass
    {
        get => _process.PriorityClass;
        set => _process.PriorityClass = value;
    }

    /// <inheritdoc />
    public bool PriorityBoostEnabled
    {
        get => _process.PriorityBoostEnabled;
        set => _process.PriorityBoostEnabled = value;
    }

    /// <inheritdoc />
    public long PeakVirtualMemorySize64 => _process.PeakVirtualMemorySize64;

    /// <inheritdoc />
    public long PeakWorkingSet64 => _process.PeakWorkingSet64;

    /// <inheritdoc />
    public long PeakPagedMemorySize64 => _process.PeakPagedMemorySize64;

    /// <inheritdoc />
    public long PagedMemorySize64 => _process.PagedMemorySize64;

    /// <inheritdoc />
    public long NonPagedSystemMemorySize64 => _process.NonpagedSystemMemorySize64;

    /// <inheritdoc />
    public ProcessModuleCollection Modules => _process.Modules;

    /// <inheritdoc />
    public IntPtr MinWorkingSet
    {
        get => _process.MinWorkingSet;
        set => _process.MinWorkingSet = value;
    }

    /// <inheritdoc />
    public long PagedSystemMemorySize64 => _process.PagedSystemMemorySize64;

    /// <inheritdoc />
    public long PrivateMemorySize64 => _process.PrivateMemorySize64;

    /// <inheritdoc />
    public TimeSpan PrivilegedProcessorTime => _process.PrivilegedProcessorTime;

    /// <inheritdoc />
    public string ProcessName => _process.ProcessName;

    /// <inheritdoc />
    public long WorkingSet64 => _process.WorkingSet64;

    /// <inheritdoc />
    public StreamReader StandardError => _process.StandardError;

    /// <inheritdoc />
    public StreamReader StandardOutput => _process.StandardOutput;

    /// <inheritdoc />
    public StreamWriter StandardInput => _process.StandardInput;

    /// <inheritdoc />
    public bool EnableRaisingEvents
    {
        get => _process.EnableRaisingEvents;
        set => _process.EnableRaisingEvents = value;
    }

    /// <inheritdoc />
    public long VirtualMemorySize64 => _process.VirtualMemorySize64;

    /// <inheritdoc />
    public TimeSpan UserProcessorTime => _process.UserProcessorTime;

    /// <inheritdoc />
    public TimeSpan TotalProcessorTime => _process.TotalProcessorTime;

    /// <inheritdoc />
    public ProcessThreadCollection Threads => _process.Threads;

    /// <inheritdoc />
    public ISynchronizeInvoke SynchronizingObject
    {
        get => _process.SynchronizingObject;
        set => _process.SynchronizingObject = value;
    }

    /// <inheritdoc />
    public DateTime StartTime => _process.StartTime;

    /// <inheritdoc />
    public ProcessStartInfo StartInfo
    {
        get => _process.StartInfo;
        set => _process.StartInfo = value;
    }

    /// <inheritdoc />
    public int SessionId => _process.SessionId;

    /// <inheritdoc />
    public bool Responding => _process.Responding;

    /// <inheritdoc />
    public IntPtr ProcessorAffinity
    {
        get => _process.ProcessorAffinity;
        set => _process.ProcessorAffinity = value;
    }

    /// <inheritdoc />
    public IntPtr MaxWorkingSet
    {
        get => _process.MaxWorkingSet;
        set => _process.MaxWorkingSet = value;
    }

    /// <inheritdoc />
    public ProcessModule? MainModule => _process.MainModule;

    /// <inheritdoc />
    public string MainWindowTitle => _process.MainWindowTitle;

    /// <inheritdoc />
    public string MachineName => _process.MachineName;

    /// <inheritdoc />
    public int Id => _process.Id;

    /// <inheritdoc />
    public int HandleCount => _process.HandleCount;

    /// <inheritdoc />
    public SafeProcessHandle SafeHandle => _process.SafeHandle;

    /// <inheritdoc />
    public IntPtr Handle => _process.Handle;

    /// <inheritdoc />
    public DateTime ExitTime => _process.ExitTime;

    /// <inheritdoc />
    public bool HasExited => _process.HasExited;

    /// <inheritdoc />
    public int ExitCode => _process.ExitCode;

    /// <inheritdoc />
    public int BasePriority => _process.BasePriority;

    /// <inheritdoc />
    public IntPtr MainWindowHandle => _process.MainWindowHandle;

    /// <inheritdoc />
    public event DataReceivedEventHandler ErrorDataReceived
    {
        add => _process.ErrorDataReceived += value;
        remove => _process.ErrorDataReceived -= value;
    }

    /// <inheritdoc />
    public event DataReceivedEventHandler OutputDataReceived
    {
        add => _process.OutputDataReceived += value;
        remove => _process.OutputDataReceived -= value;
    }

    /// <inheritdoc />
    public event EventHandler Exited
    {
        add => _process.Exited += value;
        remove => _process.Exited -= value;
    }

    /// <inheritdoc />
    public void BeginErrorReadLine()
    {
        _process.BeginErrorReadLine();
    }

    /// <inheritdoc />
    public void BeginOutputReadLine()
    {
        _process.BeginOutputReadLine();
    }

    /// <inheritdoc />
    public void CancelErrorRead()
    {
        _process.CancelErrorRead();
    }

    /// <inheritdoc />
    public void CancelOutputRead()
    {
        _process.CancelOutputRead();
    }

    /// <inheritdoc />
    public void Close()
    {
        _process.Close();
    }

    /// <inheritdoc />
    public bool CloseMainWindow()
    {
        return _process.CloseMainWindow();
    }

    /// <inheritdoc />
    public void Kill()
    {
        _process.Kill();
    }

    /// <inheritdoc />
    public void Refresh()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public bool Start()
    {
        return _process.Start();
    }

    /// <inheritdoc />
    public bool WaitForExit(int milliseconds)
    {
        return _process.WaitForExit(milliseconds);
    }

    /// <inheritdoc />
    public void WaitForExit()
    {
        _process.WaitForExit();
    }

    /// <inheritdoc />
    public bool WaitForInputIdle(int milliseconds)
    {
        return _process.WaitForInputIdle(milliseconds);
    }

    /// <inheritdoc />
    public bool WaitForInputIdle()
    {
        return _process.WaitForInputIdle();
    }

    /// <inheritdoc cref="IProcess" />
    public override string ToString()
    {
        return _process.ToString();
    }


    private bool _disposed;
    /// <summary>
    /// Disposes of this class and associated resources.
    /// </summary>
    /// <param name="disposing">True if called explicitly, false if called from destructor.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            _process.Dispose();
        }

        _disposed = true;
    }

    /// <summary>
    /// Disposes of this class and associated resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
