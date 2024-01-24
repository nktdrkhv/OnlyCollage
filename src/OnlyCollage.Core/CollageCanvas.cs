using System.Collections.Generic;

namespace OnlyCollage.Core;

public class CollageCanvas
{
    private readonly ICollageCell _imageTree;
    private int _width;
    // private type _backgroundColor;

    public CollageCanvas(ICollageCell imageTree, int width) => (_imageTree, _width) = (imageTree, width);
}