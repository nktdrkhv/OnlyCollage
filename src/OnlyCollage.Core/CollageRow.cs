using System.Linq;

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
        var totalWidth = Cells.Sum(cell => cell.Width);
        return this;
    }
}