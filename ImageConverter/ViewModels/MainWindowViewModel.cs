using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ImageConverter.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _inputPath = "";
    [ObservableProperty]
    private string _outputPath = "";

    [RelayCommand]
    private void ChooseInputFile()
    {
        //TODO
    }

    [RelayCommand]
    private void ChooseOutputFile()
    {
        //TODO
    }
}
