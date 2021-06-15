using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilDrawing.Class
{
    class RetainingWall
    {
        public double stemHeight;
        public double stemThickness;
        public double baseLength;
        public double baseThickness;
        public double toeLength;

        public List<XY> xyList;

        public RetainingWall(double stemHeight, double stemThickness, double baseLength, double baseThickness, double toeLength)
        {
            this.stemHeight = stemHeight;
            this.stemThickness = stemThickness;
            this.baseLength = baseLength;
            this.baseThickness = baseThickness;
            this.toeLength = toeLength;
            CreateXYList();
        }

        private void CreateXYList()
        {
            xyList = new List<XY>();

            XY xy = new XY(0, 0);
            xyList.Add(xy);

            xy = new XY(0, baseThickness);
            xyList.Add(xy);

            xy = new XY(toeLength, baseThickness);
            xyList.Add(xy);

            xy = new XY(toeLength, baseThickness + stemHeight);
            xyList.Add(xy);

            xy = new XY(toeLength + stemThickness, baseThickness + stemHeight);
            xyList.Add(xy);

            xy = new XY(toeLength + stemThickness, baseThickness);
            xyList.Add(xy);

            xy = new XY(baseLength, baseThickness);
            xyList.Add(xy);

            xy = new XY(baseLength, 0);
            xyList.Add(xy);

            xy = new XY(0, 0);
            xyList.Add(xy);
        }
    }
}
