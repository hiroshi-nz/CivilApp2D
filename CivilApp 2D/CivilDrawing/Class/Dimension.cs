using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilDrawing.Class
{
    class Dimension
    {

        public List<XY> arrowUp;
        public List<XY> arrowDown;
        public List<XY> shaft;

        public double length;

        public List<List<XY>> drawingList;

        double arrowY = 10;
        double arrowX = 10;

        public Dimension(double length)
        {
            this.length = length;


            ArrowUp();
            ArrowDown();
            Shaft();
            CreateDrawingList();
        }

        private void ArrowUp()
        {
            arrowUp = new List<XY>();
            XY xy = new XY(-arrowX, length - arrowY);
            arrowUp.Add(xy);

            xy = new XY(0, length);
            arrowUp.Add(xy);

            xy = new XY(+arrowX, length - arrowY);
            arrowUp.Add(xy);
        }

        private void ArrowDown()
        {
            arrowDown = new List<XY>();
            XY xy = new XY(-arrowX, arrowY);
            arrowDown.Add(xy);

            xy = new XY(0, 0);
            arrowDown.Add(xy);

            xy = new XY(+arrowX, arrowY);
            arrowDown.Add(xy);
        }

        private void Shaft()
        {
            shaft = new List<XY>();
            XY xy = new XY(0, 0);
            shaft.Add(xy);

            xy = new XY(0, length);
            shaft.Add(xy);
        }

        private void CreateDrawingList()
        {
            drawingList = new List<List<XY>>();

            drawingList.Add(arrowUp);
            drawingList.Add(arrowDown);
            drawingList.Add(shaft);
        }
    }
}
