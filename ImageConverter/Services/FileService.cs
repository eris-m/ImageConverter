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
        var options = new FilePickerOpenOptions();
        var files = await _window.StorageProvider.OpenFilePickerAsync(options);

        return files.Any() ? files[0] : null;
    }
}