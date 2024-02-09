using System;
using System.Collections;
using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Metadata;

namespace OnlyCollage.Core;

public class CollageImage : ICollageCell
{
    private int _height;
    private int _width;
    private UpperLeftPoint? _position;

    public CollageImage(string path)
    {
        var info = Image.Identify(path);
        _height = info.Height;
        _width = info.Width;
        Path = path;
    }

    public UpperLeftPoint Position
    {
        get
        {
            _position ??= new(0, 0);
            return _position;
        }
        set => _position = value;
    }
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
    public double ScaleFactor { get; set; } = 1.0;
    public string Path { get; }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public IEnumerator<CollageImage> GetEnumerator()
    {
        yield return this;
    }

    public ICollageCell Apply(int width, UpperLeftPoint? position = null)
    {
        Position = position ?? new(0, 0);
        Height = (int)((double)width / Width * Height);
        Width = width;
        ScaleFactor = 1.0;
        return this;
    }
}