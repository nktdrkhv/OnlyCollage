using OnlyCollage.Core;

var img1 = new CollageImage(Path.Combine("Pics", "1.jpg"));
var img2 = new CollageImage(Path.Combine("Pics", "2.jpg"));
var img3 = new CollageImage(Path.Combine("Pics", "3.jpg"));
var img4 = new CollageImage(Path.Combine("Pics", "4.jpg"));
var img5 = new CollageImage(Path.Combine("Pics", "5.jpg"));
var img6 = new CollageImage(Path.Combine("Pics", "6.jpg"));
var img7 = new CollageImage(Path.Combine("Pics", "7.jpg"));

var row = new CollageRow();
var col1 = new CollageColumn();
var col2 = new CollageColumn();
var row1 = new CollageRow();

col1.Add(img1).Add(img2);
row1.Add(img6).Add(img4);
col2.Add(img5).Add(row1).Add(img3);
row.Add(col1).Add(img7).Add(col2);

var collage = new CollageCanvas(row, 1500, new(0, 0));
collage.Combine(Path.Combine("Pics", "output.jpg"));