using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilDrawing.Class
{
    class Circle
    {
        public List<XY> xyList;

        public double diameter;
        public double radius;
        public double resolution;

        public Circle(double diameter, double resolution)
        {
            this.diameter = diameter;
            this.resolution = resolution;
            radius = diameter / 2;

            CreateXYList();
        }


        private void CreateXYList()
        {
            xyList = new List<XY>();

            double increment = 360/resolution;

            for (double d = 0; d < 360; d += increment)
            {
                XY xy = new XY(radius * Math.Cos(Math.PI * d/180), radius * Math.Sin(Math.PI * d / 180));
                xyList.Add(xy);
            }

            XY xyEnd = new XY(radius * Math.Cos(0), radius * Math.Sin(0));
            xyList.Add(xyEnd);

        }


    }
}
