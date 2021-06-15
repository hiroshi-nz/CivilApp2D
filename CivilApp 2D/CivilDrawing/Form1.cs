using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CivilDrawing.Class;

namespace CivilDrawing
{
    public partial class Form1 : Form
    {

        Elements elements;
        Drawings drawings;

        public Form1()
        {
            InitializeComponent();

            elements = new Elements();
            //RetainingWall retainingWall = new RetainingWall(3000, 200, 1500, 200, 500);
            //Draw2D.Draw(pictureBox1, retainingWall.xyList, 0.1);
            ConcreteBeam concreteBeam1 = new ConcreteBeam(500, 300, 40, new Class.XY(0, 0));
            elements.Add(concreteBeam1);

            ConcreteBeam concreteBeam2 = new ConcreteBeam(200, 200, 40, new Class.XY(400, 0));
            elements.Add(concreteBeam2);

            ConcreteBeam concreteBeam3 = new ConcreteBeam(150, 150, 20, new Class.XY(400, 300));
            elements.Add(concreteBeam3);

            drawings = elements.CreateDrawings();
            drawings.Draw(pictureBox1);

        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int elementID = drawings.SelectElement(e.Location.X, e.Location.Y);
            List<Item> viewList = elements.SearchByElementID(elementID);

            drawings.Draw(pictureBox1);

            UIHelper.DataGridView(dataGridView1, viewList);
        }
    }
}
