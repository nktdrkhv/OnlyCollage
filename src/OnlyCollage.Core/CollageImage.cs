using System;
using System.Collections;
using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Metadata;

namespace OnlyCollage.Core;

public class CollageImage : ICollageCell
{
    private readonly string _path;
    private int _height;
    private int _width;

    public CollageImage(string path)
    {
        var info = Image.Identify(path);
        _height = info.Height;
        _width = info.Width;
        _path = path;
    }

    public Point UpperLeftPointer { get; set; }
    public int Height
    {
        get => (int)(_height * ScaleFactor);
        set => _height = value;
    }
    public int Width
    {
        get => (int)(_width * ScaleFactor);
        set => _width = value;
    }
    public double ScaleFactor { get; set; }
    public double HorizontalProportion => Width / Height;
    public double VertialProporion => Height / Width;

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    public IEnumerator<CollageImage> GetEnumerator()
    {
        yield return this;
    }

    public ICollageCell Apply(int width)
    {

        return this;
    }
}