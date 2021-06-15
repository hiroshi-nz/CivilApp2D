using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CivilDrawing.Class
{
    class DrawingHelper
    {
        public static List<XY> Scale(List<XY> xyList, double factor)
        {
            List<XY> newXYList = new List<XY>();

            foreach(XY xy in xyList)
            {
                newXYList.Add(new XY(xy.x * factor, xy.y * factor));
            }

            return newXYList;
        }

        public static List<XY> Move(List<XY> xyList, double x, double y)
        {
            List<XY> newXYList = new List<XY>();

            foreach (XY xy in xyList)
            {
                newXYList.Add(new XY(xy.x + x, xy.y + y));
            }

            return newXYList;
        }

        public static List<XY> Move(List<XY> xyList, XY xy)
        {
            List<XY> newXYList = new List<XY>();

            foreach (XY currentXY in xyList)
            {
                newXYList.Add(new XY(currentXY.x + xy.x, currentXY.y + xy.y));
            }

            return newXYList;
        }

        public static List<List<XY>> Move(List<List<XY>> drawingList, double x, double y)
        {
            List<List<XY>> newDrawingList = new List<List<XY>>();

            foreach (List<XY> xyList in drawingList)
            {
                newDrawingList.Add(Move(xyList, x, y));
            }

            return newDrawingList;
        }

        public static PointF[] XYtoPointF(List<XY> xyList)
        {
            int length = xyList.Count;

            PointF[] pointFArray = new PointF[length];
            
            for(int i = 0; i < length; i++)
            {
                pointFArray[i].X = Convert.ToSingle(xyList[i].x);
                pointFArray[i].Y = Convert.ToSingle(xyList[i].y);
            }
            return pointFArray;
        }

        

    }
}
