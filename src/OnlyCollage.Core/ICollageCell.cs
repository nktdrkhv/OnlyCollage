using System.Collections.Generic;

namespace OnlyCollage.Core;

public interface ICollageCell : IEnumerable<CollageImage>
{
    UpperLeftPoint Position { get; }
    int Height { get; }
    int Width { get; }
    double ScaleFactor { get; set; }
    ICollageCell Apply(int width, UpperLeftPoint? position = null);
}