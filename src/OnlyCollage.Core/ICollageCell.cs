namespace OnlyCollage.Core;

public interface ICollageCell
{
    int Length { get; }
    int Weight { get; }
    double ScaleFactor { get; }
    double HorizontalProportion { get; }
    double VertialProporion { get; }

    //void Apply(int width);
}