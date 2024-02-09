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
        var widest = Cells.MaxBy(cell => (double)cell.Width / cell.Height)!;
        for (int i = 0; i < Cells.Count; i++)
            if (widest != Cells[i])
                Cells[i].ScaleFactor = (double)widest.Height / Cells[i].Height;
        return widest;
    }

    public override ICollageCell Apply(int width, UpperLeftPoint? position = null)
    {
        position ??= new(0, 0);
        Basis ??= ScaleByLargestProportion();
        var shift = 0;
        var totalWidth = Cells.Sum(cell => cell.Width);
        var proportion = (double)width / totalWidth;
        foreach (var cell in Cells)
        {
            var childPosition = position with { X = position.X + shift };
            var childWidth = (int)(cell.Width * proportion);
            cell.Apply(childWidth, childPosition);
            shift += cell.Width;
        }
        Height = -1;
        Width = -1;
        ScaleFactor = 1.0;
        return this;
    }
}