using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace OnlyCollage.Core;

public class CollageCanvas
{
    private readonly ICollageCell _imageTree;
    private readonly UpperLeftPoint _position;
    private readonly int _width;
    // private type _backgroundColor;

    public CollageCanvas(ICollageCell imageTree, int width, UpperLeftPoint position) =>
        (_imageTree, _width, _position) = (imageTree, width, position);

    public void Combine(string path)
    {
        _imageTree.Apply(_width, _position);
        var output = new Image<Rgba32>(_width, _imageTree.Height);
        foreach (var image in _imageTree)
        {
            using var loadedImage = Image.Load<Rgba32>(image.Path);
            var size = new Size(image.Width, image.Height);
            var point = new Point(image.Position.X, image.Position.Y);
            loadedImage.Mutate(o => o.Resize(size));
            output.Mutate(o => o.DrawImage(loadedImage, point, 1.0f));
        }
        output.SaveAsJpeg(path);
    }
}