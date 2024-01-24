namespace OnlyCollage.Core;

public class CollageRow : CollageLineBase, IAddCollageCell<CollageRow, CollageColumn>
{
    public CollageRow Add(CollageColumn column) => (CollageRow)base.Add(column);
}