using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CivilDrawing.Class
{
    class Elements
    {
        int IDCounter;
        List<ConcreteBeam> concreteBeamList;

        public Elements()
        {
            concreteBeamList = new List<ConcreteBeam>();
            IDCounter = 0;
        }

        public void Add(ConcreteBeam concreteBeam)
        {
            IDCounter += 1;
            concreteBeam.elementID = IDCounter;
            concreteBeamList.Add(concreteBeam);
            
        }

        public List<Item> SearchByElementID(int elementID)
        {
            foreach(ConcreteBeam concreteBeam in concreteBeamList)
            {
                if(concreteBeam.elementID == elementID)
                {
                    Console.WriteLine("match found. Beam ID:" + concreteBeam.elementID);
                    concreteBeam.CreateList();
                    return concreteBeam.viewList1;
                }
            }

            List<Item> emptyList = new List<Item>();
            return emptyList;
        }

        public Drawings CreateDrawings()
        {
            Drawings drawings = new Drawings();

            foreach (ConcreteBeam concreteBeam in concreteBeamList)
            {
                concreteBeam.AddDrawings(drawings, Color.Black);
            }
            return drawings;
        }
    }
}
