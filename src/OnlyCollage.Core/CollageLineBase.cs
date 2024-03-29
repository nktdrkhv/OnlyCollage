using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace OnlyCollage.Core;

public abstract class CollageLineBase : ICollageCell, IAddCollageCell<CollageLineBase, CollageImage>
{
    private readonly List<ICollageCell> _cells = [];
    private int _height = -1;
    private int _width = -1;

    protected ICollageCell? Basis { get; set; }
    protected List<ICollageCell> Cells { get => _cells; }

    public UpperLeftPoint Position => _cells[0].Position;
    public double ScaleFactor { get; set; } = 1.0;
    public int Height
    {
        get
        {
            if (_height < 0)
                _height = CombineHeight();
            return (int)Math.Round(_height * ScaleFactor);
        }
        protected set => _height = value;
    }
    public int Width
    {
        get
        {
            if (_width < 0)
                _width = CombineWidth();
            return (int)Math.Round(_width * ScaleFactor);
        }
        protected set => _width = value;
    }

    public abstract CollageLineBase Add(CollageImage image);

    protected virtual CollageLineBase Add(ICollageCell cell)
    {
        _cells.Add(cell);
        _height = -1;
        _width = -1;
        Basis = null;
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<CollageImage> GetEnumerator()
    {
        foreach (var cell in _cells)
            foreach (var image in cell)
                yield return image;
    }

    protected abstract ICollageCell ScaleByLargestProportion();
    protected abstract int CombineHeight();
    protected abstract int CombineWidth();

    public abstract ICollageCell Apply(int width, UpperLeftPoint? position = null);
}