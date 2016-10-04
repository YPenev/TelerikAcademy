using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public class Simple3DFigure : IFigureIn3D
    {
        private double depth;
        private double height;
        private double width;

        public Simple3DFigure(double depth, double height, double width)
        {
            this.Depth = depth;
            this.Height = height;
            this.Width = width;
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }
            set
            {
                if (value > 0)
                {
                    this.depth = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
