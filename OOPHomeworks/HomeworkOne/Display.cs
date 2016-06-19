using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOneGSM
{
    public class Displays
    {
        private double size;
        private long numberOfColours;


        public Displays(double size, long numberOfColours)
        {
            this.size = size;
            this.numberOfColours = numberOfColours;
        }
        public Displays()
            : this(0, 0)
        {
        }

        public double Size				//Пропърти
        {
            get { return this.size; }
            set {
                if (value <= 0 )
                {
                    throw new ArgumentException("Size must be positive !");
                }
                this.size = value; }
        }
        public long NumberOfColours				//Пропърти
        {
            get { return this.numberOfColours; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentException("NumberOfColours must be positive !");
                } 
                this.numberOfColours = value;
            }
        }

        public override string ToString()   //Метод
        {
            return string.Format("Size - {0}, NumberOfColours -  {1}",
                 this.size, this.numberOfColours);
        }
    }
}
