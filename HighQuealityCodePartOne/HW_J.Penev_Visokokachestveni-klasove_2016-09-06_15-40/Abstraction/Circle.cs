using System;

namespace Abstraction
{
    class Circle : IFigureIn2D
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }
        

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value > 0)
                {
                    this.radius = value;
                }
                else
                {
                    throw new ArgumentException("Radius can not be negative !");
                }
            }
        }
        
        public  double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public  double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
