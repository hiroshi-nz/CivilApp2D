using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CivilDrawing.Class
{
    class Drawing
    {
        public int elementID;
        public Color drawingID;
        public Color color;
        public bool IsSelected;
        public List<XY> xyList;

        public Drawing(int elementID, Color drawingID, List<XY> xyList, Color color)
        {
            this.elementID = elementID;
            this.drawingID = drawingID;
            this.xyList = xyList;
            this.color = color;
            IsSelected = false;
    }
    }
}
