using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImageConverter.Services;

namespace ImageConverter.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _inputPath = "";
    [ObservableProperty]
    private string _outputPath = "";

    [RelayCommand]
    private async Task ChooseInputFile()
    {
        InputPath = await OpenFile() ?? "";
    }

    [RelayCommand]
    private async Task ChooseOutputFile()
    {
        OutputPath = await OpenFile() ?? "";
    }

    private static async Task<string?> OpenFile()
    {
        try
        {
            var service = App.Current?.ServiceProvider?.GetService(typeof(FileService));
            if (service == null)
                throw new NullReferenceException("No file service!");
        
            if (service is not FileService fileService)
                throw new Exception("File service not FileService!");
        
            var file = await fileService.OpenFile();
            return file?.Path.AbsolutePath;
        }
        catch (Exception e)
        {
            await Console.Error.WriteLineAsync(e.ToString());
            return null;
        }
    }
}
