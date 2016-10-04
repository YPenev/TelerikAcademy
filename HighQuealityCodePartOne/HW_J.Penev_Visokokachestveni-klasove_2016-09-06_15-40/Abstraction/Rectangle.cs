using System;

namespace Abstraction
{
    class Rectangle : IFigureIn2D
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
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
                    throw new ArgumentException("Width can not be negative !");
                }
            }
        }

        public virtual double Height
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
                    throw new ArgumentException("Height can not be negative !");
                }
            }
        }

        public  double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public  double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
