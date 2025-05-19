using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace ImageConverter.Services;

public class FileService
{
    private Window _window;

    public FileService(Window window)
    {
        _window = window;
    }

    public async Task<IStorageFile?> OpenFile()
    {
        var options = new FilePickerOpenOptions
        {
            Title = "Open Input - ImageConverter",
            AllowMultiple = false,
            FileTypeFilter = [FilePickerFileTypes.ImageAll]
        };
        
        var files = await _window.StorageProvider.OpenFilePickerAsync(options);

        return files.Any() ? files[0] : null;
    }

    public async Task<IStorageFile?> SaveFile()
    {
        var options = new FilePickerSaveOptions
        {
            Title = "Output - ImageConverter",
            FileTypeChoices = [FilePickerFileTypes.ImageAll],
            ShowOverwritePrompt = true
        };

        return await _window.StorageProvider.SaveFilePickerAsync(options);
    }
}