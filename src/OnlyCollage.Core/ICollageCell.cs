using System.Collections.Generic;
using SixLabors.ImageSharp;

namespace OnlyCollage.Core;

public interface ICollageCell : IEnumerable<CollageImage>
{
    Point UpperLeftPointer { get; set; }
    int Height { get; }
    int Width { get; }
    double ScaleFactor { get; set; }
    double HorizontalProportion { get; }
    double VertialProporion { get; }
    ICollageCell Apply(int width);
}