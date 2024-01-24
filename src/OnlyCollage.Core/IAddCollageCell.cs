namespace OnlyCollage.Core;

public interface IAddCollageCell<out TItself, in TNestedCell>
    where TItself : notnull, IAddCollageCell<TItself, TNestedCell>
    where TNestedCell : notnull, ICollageCell
{
    TItself Add(TNestedCell cell);
}