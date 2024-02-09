using OnlyCollage.Core;

var img1 = new CollageImage(Path.Combine("Pics", "1.jpg"));
var img2 = new CollageImage(Path.Combine("Pics", "2.jpg"));
var img3 = new CollageImage(Path.Combine("Pics", "3.jpg"));
var img4 = new CollageImage(Path.Combine("Pics", "4.jpg"));
var img5 = new CollageImage(Path.Combine("Pics", "5.jpg"));
var img6 = new CollageImage(Path.Combine("Pics", "6.jpg"));
var img7 = new CollageImage(Path.Combine("Pics", "7.jpg"));

var row = new CollageRow();
row.Add(img1).Add(img2).Add(img3);

var collage = new CollageCanvas(row, 640, new(0, 0));
collage.Combine(Path.Combine("Pics", "output.jpg"));