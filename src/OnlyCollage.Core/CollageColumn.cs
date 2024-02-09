using System.Linq;

namespace OnlyCollage.Core;

public class CollageColumn : CollageLineBase, IAddCollageCell<CollageColumn, CollageRow>
{
    protected override int CombineHeight()
    {
        Basis ??= ScaleByLargestProportion();
        return Cells.Sum(cell => cell.Height);
    }

    protected override int CombineWidth()
    {
        Basis ??= ScaleByLargestProportion();
        return Basis.Width;
    }

    public override CollageColumn Add(CollageImage image) => (CollageColumn)base.Add((ICollageCell)image);
    public CollageColumn Add(CollageRow row) => (CollageColumn)base.Add(row);

    protected override ICollageCell ScaleByLargestProportion()
    {
        var tallest = Cells.MaxBy(cell => (double)cell.Height / cell.Width)!;
        for (int i = 0; i < Cells.Count; i++)
            if (tallest != Cells[i])
                Cells[i].ScaleFactor = (double)tallest.Width / Cells[i].Width;
        return tallest;
    }

    public override ICollageCell Apply(int width, UpperLeftPoint? position = null)
    {
        position ??= new(0, 0);
        if (Basis is null)
            ScaleByLargestProportion();
        var shift = 0;
        foreach (var cell in Cells)
        {
            var childPosition = position with { Y = position.Y + shift };
            cell.Apply(width, childPosition);
            shift += cell.Height;
        }
        Height = -1;
        Width = -1;
        ScaleFactor = 1.0;
        return this;
    }
}