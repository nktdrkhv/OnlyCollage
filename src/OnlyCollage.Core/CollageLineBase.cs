using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OnlyCollage.Core;

public abstract class CollageLineBase : ICollageCell, IAddCollageCell<CollageLineBase, CollageImage>
{
    private readonly List<ICollageCell> _cells = new();

    public double ScaleFactor { get; protected set; } = 1.0;
    public int Height => _cells.Sum(cell => cell.Height);
    public int Width => _cells.Sum(cell => cell.Width);
    public double HorizontalProportion => _cells.Max(cell => cell.HorizontalProportion);
    public double VertialProporion => _cells.Max(cell => cell.VertialProporion);

    public virtual CollageLineBase Add(CollageImage image) => Add((ICollageCell)image);

    protected virtual CollageLineBase Add(ICollageCell cell)
    {
        _cells.Add(cell);
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    public IEnumerator<CollageImage> GetEnumerator()
    {
        foreach (var cell in _cells)
            foreach (var image in cell)
                yield return image;
    }

    protected abstract void FitByLargestProportion();

    public ICollageCell Apply(int width)
    {
        FitByLargestProportion();
        return this;
    }
}