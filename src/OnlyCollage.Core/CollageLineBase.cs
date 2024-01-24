using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace OnlyCollage.Core;

public abstract class CollageLineBase : ICollageCell, IAddCollageCell<CollageLineBase, CollageImage>
{
    private readonly List<ICollageCell> _cells = new();

    public double ScaleFactor { get; protected set; } = 1.0;
    public int Length => _cells.Sum(cell => cell.Length);
    public int Weight => _cells.Sum(cell => cell.Weight);
    public double HorizontalProportion => _cells.Max(cell => cell.HorizontalProportion);
    public double VertialProporion => _cells.Max(cell => cell.VertialProporion);

    public virtual CollageLineBase Add(CollageImage image) => Add((ICollageCell)image);

    protected virtual CollageLineBase Add(ICollageCell cell)
    {
        _cells.Add(cell);
        return this;
    }

    //protected void FitByLargestProportion
}