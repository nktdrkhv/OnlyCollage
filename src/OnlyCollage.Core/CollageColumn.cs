namespace OnlyCollage.Core;

public class CollageColumn : CollageLineBase, IAddCollageCell<CollageColumn, CollageRow>
{
    public CollageColumn Add(CollageRow row) => (CollageColumn)base.Add(row);
}