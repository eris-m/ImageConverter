//using Avalonia.Controls;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Models;

public static class Converter
{
    public static async Task ConvertImage(string inputPath, string outputPath)
    {
        var image = await Image.LoadAsync(inputPath);
        await image.SaveAsync(outputPath);
    }
}

