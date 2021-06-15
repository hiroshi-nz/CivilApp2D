using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CivilDrawing.Class
{
    class Drawings
    {
        ColorCounter colorCounter;
        List<Drawing> drawingList;

        Bitmap displayImage;
        Bitmap clickImage;

        public Drawings()
        {
            drawingList = new List<Drawing>();
            colorCounter = new ColorCounter();
            
        }

        public void Add(int elementID, List<XY> xyList, Color color)
        {
            Color drawingID = colorCounter.Tick();
            Drawing drawing = new Drawing(elementID, drawingID, xyList, color);
            drawingList.Add(drawing);
        }

        public void Draw(PictureBox pictureBox)
        {
            DrawDisplayImage(pictureBox);
            DrawClickImage(pictureBox);
        }


        private void DrawDisplayImage(PictureBox pictureBox)
        {
            displayImage = new Bitmap(pictureBox.Width, pictureBox.Height,
                                        System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (Graphics graphics = Graphics.FromImage(displayImage))
            {
                graphics.Clear(Color.White);
                foreach (Drawing drawing in drawingList)
                {
                    PointF[] pointFArray = DrawingHelper.XYtoPointF(drawing.xyList);
                    GraphicsPath gPath = new GraphicsPath();
                    gPath.AddLines(pointFArray);
                    
                    if (drawing.IsSelected)
                    {
                        graphics.FillPath(new SolidBrush(Color.Salmon), gPath);
                        graphics.DrawLines(new Pen(Color.Red, 3), pointFArray);
                    }
                    else
                    {
                        
                        graphics.FillPath(new SolidBrush(Color.White), gPath);
                        graphics.DrawLines(new Pen(drawing.color, 2), pointFArray);
                    }


                }
            }

            pictureBox.Image = displayImage;
        }

        private void DrawClickImage(PictureBox pictureBox)
        {

            clickImage = new Bitmap(pictureBox.Width, pictureBox.Height,
                                        System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (Graphics graphics = Graphics.FromImage(clickImage))
            {
                graphics.Clear(Color.White);
                foreach (Drawing drawing in drawingList)
                {
                    PointF[] pointFArray = DrawingHelper.XYtoPointF(drawing.xyList);
                    GraphicsPath gPath = new GraphicsPath();
                    gPath.AddLines(pointFArray);
                    graphics.FillPath(new SolidBrush(drawing.drawingID), gPath);
                }

            }
        }

        public int SelectElement(int x, int y)
        {
            Color color = clickImage.GetPixel(x, y);

            foreach(Drawing drawing in drawingList)
            {
                if(drawing.drawingID == color)
                {
                    ChangeIsSelected(drawing.elementID);
                    return drawing.elementID;
                }
            }
            return 100000;
        }


        private void ChangeIsSelected(int elementID)
        {
            foreach(Drawing drawing in drawingList)
            {
                if(drawing.elementID == elementID)
                {
                    drawing.IsSelected = true;
                }
                else
                {
                    drawing.IsSelected = false;
                }
            }
        }
    }
}
