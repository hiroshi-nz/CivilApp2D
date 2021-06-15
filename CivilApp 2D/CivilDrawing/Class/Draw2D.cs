using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CivilDrawing.Class
{
    class Draw2D
    {

        public static void Draw(PictureBox pictureBox, List<XY> xyList, double scale)
        {

            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height,
                                        System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            xyList = DrawingHelper.Scale(xyList, scale);
            PointF[] pointFArray = DrawingHelper.XYtoPointF(xyList);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);

                graphics.DrawLines(Pens.Black, pointFArray);
            }
            pictureBox.Image = bitmap;
        }

        public static void Draw(PictureBox pictureBox, List<List<XY>> drawingList)
        {

            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height,
                                        System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);

                foreach (List<XY> xyList in drawingList)
                {
                    //List<XY> newXYList = DrawingHelper.Scale(xyList, 0.1);
                    //PointF[] pointFArray = DrawingHelper.XYtoPointF(newXYList);
                    PointF[] pointFArray = DrawingHelper.XYtoPointF(xyList);
                    graphics.DrawLines(Pens.Black, pointFArray);
                }

            }

            pictureBox.Image = bitmap;
        }

        public static Bitmap DrawFill(PictureBox pictureBox, List<List<XY>> drawingList)
        {

            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height,
                                        System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);

                ColorCounter changeColor = new ColorCounter(0, 0, 0, 50);

                foreach (List<XY> xyList in drawingList)
                {
                    //List<XY> newXYList = DrawingHelper.Scale(xyList, 0.1);
                    //PointF[] pointFArray = DrawingHelper.XYtoPointF(newXYList);
                    PointF[] pointFArray = DrawingHelper.XYtoPointF(xyList);

                    GraphicsPath gPath = new GraphicsPath();
                    gPath.AddLines(pointFArray);
                    graphics.FillPath(new SolidBrush(changeColor.Tick()), gPath);


                    
                    graphics.DrawLines(Pens.Black, pointFArray);
                }

            }

            Color color = bitmap.GetPixel(30, 50);
            Console.WriteLine("R:" + color.R + " G:" + color.G + "B:" + color.B);

            pictureBox.Image = bitmap;
            return bitmap;
        }

    }
}
