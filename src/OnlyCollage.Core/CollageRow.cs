using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace OnlyCollage.Core;

public class CollageRow : CollageLineBase, IAddCollageCell<CollageRow, CollageColumn>
{
    protected override int CombineHeight()
    {
        Basis ??= ScaleByLargestProportion();
        return Basis.Height;
    }

    protected override int CombineWidth()
    {
        Basis ??= ScaleByLargestProportion();
        return Cells.Sum(cell => cell.Width);
    }

    public override CollageRow Add(CollageImage image) => (CollageRow)base.Add((ICollageCell)image);
    public CollageRow Add(CollageColumn column) => (CollageRow)base.Add(column);

    protected override ICollageCell ScaleByLargestProportion()
    {
        var widest = Cells.MaxBy(cell => cell.Height / cell.Width)!;
        for (int i = 0; i < Cells.Count; i++)
            if (widest != Cells[i])
                Cells[i].ScaleFactor = widest.Height / Cells[i].Height;
        return widest;
    }

    public override ICollageCell Apply(int width, UpperLeftPoint? position = null)
    {
        position ??= new(0, 0);
        var totalWidth = Cells.Sum(cell => cell.Width);
        var proportion = width / totalWidth;
        var shift = 0;
        foreach (var cell in Cells)
        {
            var childPosition = position with { X = position.X + shift };
            var childWidth = cell.Width * proportion;
            cell.Apply(childWidth, childPosition);
            shift += cell.Width;
        }
        return this;
    }
}