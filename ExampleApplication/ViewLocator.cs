using HanumanInstitute.MvvmDialogs.Avalonia;

namespace HanumanInstitute.FFmpegExampleApplication;

/// <summary>
/// Maps view models to views in Avalonia.
/// </summary>
public class ViewLocator : ViewLocatorBase
{
    /// <inheritdoc />
    protected override string GetViewName(object viewModel) => viewModel.GetType().FullName!.Replace("ViewModel", "View");
}
