using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CivilDrawing.Class
{
    class ColorCounter
    {
        public int red;
        public int green;
        public int blue;
        public int increment;
        public int max = 255;
        

        public ColorCounter(int red,  int green, int blue, int increment)
        {
            this.red = MoreThanMax(red, max);
            this.green = MoreThanMax(green, max);
            this.blue = MoreThanMax(blue, max);

            if(increment > max)
            {
                this.increment = 15;
            }
            else
            {
                this.increment = increment;
            }
        }

        public ColorCounter()
        {
            this.red = 0;
            this.green = 0;
            this.blue = 0;
            this.increment = 1;
        }

        public Color Tick()
        {
            red += increment;
            if(red > max)
            {
                red = 0;

                green += increment;

                if(green > max)
                {
                    green = 0;

                    blue += increment;

                    if(blue > max)
                    {
                        blue = 0;
                    }
                }
            }
            return Color.FromArgb(red, green, blue);
        }

        private int MoreThanMax(int input, int max)
        {
            if (input <= max)
            {
                return input;
            }
            else
            {
                return 0;
            }
        }

    }
}
