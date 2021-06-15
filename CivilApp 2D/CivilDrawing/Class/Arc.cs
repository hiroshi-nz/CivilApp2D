using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilDrawing.Class
{
    class Arc
    {

        public List<XY> xyList;

        public double diameter;
        public double radius;
        public double resolution;
        public double startAngle;
        public double endAngle;


        public Arc(double diameter, double resolution, double startAngle, double endAngle)
        {
            this.diameter = diameter;
            this.resolution = resolution;
            this.startAngle = startAngle;
            this.endAngle = endAngle;

            radius = diameter / 2;

            CreateXYList();
        }
        private void CreateXYList()
        {
            xyList = new List<XY>();

            double increment = 360 / resolution;

            for (double d = startAngle; d < endAngle; d += increment)
            {
                XY xy = new XY(radius * Math.Cos(Math.PI * d / 180), radius * Math.Sin(Math.PI * d / 180));
                xyList.Add(xy);
            }

            XY xyEnd = new XY(radius * Math.Cos(Math.PI * endAngle / 180), radius * Math.Sin(Math.PI * endAngle / 180));
            xyList.Add(xyEnd);

        }
    }
}

