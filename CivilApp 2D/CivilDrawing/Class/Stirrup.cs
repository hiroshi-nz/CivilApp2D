using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilDrawing.Class
{
    class Stirrup
    {
        public List<XY> xyList;
        
        public double height;
        public double width;
        public double diameter;
        public double resolution;
        public double radius;


        public Stirrup(double height, double width, double diameter, double resolution)
        {
            this.height = height;
            this.width = width;
            this.diameter = diameter;
            radius = diameter / 2;
            this.resolution = resolution;

            CreateXYList();
        }


        private void CreateXYList()
        {
            xyList = new List<XY>();

            Arc arc = new Arc(diameter, resolution, 180, 270);
            List<XY> MovedXYList = DrawingHelper.Move(arc.xyList, radius, radius);

            foreach (XY movedXY in MovedXYList)
            {
                xyList.Add(movedXY);
            }

            arc = new Arc(diameter, resolution, 270, 360);
            MovedXYList = DrawingHelper.Move(arc.xyList, width - radius, radius);

            foreach (XY movedXY in MovedXYList)
            {
                xyList.Add(movedXY);
            }

            arc = new Arc(diameter, resolution, 0, 90);
            MovedXYList = DrawingHelper.Move(arc.xyList, width - radius, height - radius);

            foreach (XY movedXY in MovedXYList)
            {
                xyList.Add(movedXY);
            }

            arc = new Arc(diameter, resolution, 90, 180);
            MovedXYList = DrawingHelper.Move(arc.xyList, radius, height - radius);

            foreach (XY movedXY in MovedXYList)
            {
                xyList.Add(movedXY);
            }

            XY xy = new XY(0, radius);
            xyList.Add(xy);

            /*
            XY xy = new XY(0, 0);
            xyList.Add(xy);
            
            xy = new XY(width, 0);
            xyList.Add(xy);

            xy = new XY(width, height);
            xyList.Add(xy);

            xy = new XY(0, height);
            xyList.Add(xy);

            xy = new XY(0, 0);
            xyList.Add(xy);
            */
        }
    }
}

