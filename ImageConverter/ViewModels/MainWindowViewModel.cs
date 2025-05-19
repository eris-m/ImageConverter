using System;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
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
        InputPath = await OpenFile(false) ?? "";
    }

    [RelayCommand]
    private async Task ChooseOutputFile()
    {
        OutputPath = await OpenFile(true) ?? "";
    }

    [RelayCommand]
    private async Task Convert()
    { 
        //TODO
    }

    [RelayCommand]
    private static void QuitProgram()
    {
        Environment.Exit(0);
    }

    private static async Task<string?> OpenFile(bool save)
    {
        try
        {
            var service = App.Current?.ServiceProvider?.GetService(typeof(FileService));
            if (service == null)
                throw new NullReferenceException("No file service!");
        
            if (service is not FileService fileService)
                throw new Exception("File service not FileService!");

            IStorageFile? file;
            
            if (save)
            {
                file = await fileService.SaveFile();
                return file?.Path.AbsolutePath;
                
            }
            
            file = await fileService.OpenFile();
            return file?.Path.AbsolutePath;
        }
        catch (Exception e)
        {
            await Console.Error.WriteLineAsync(e.ToString());
            return null;
        }
    }
}
