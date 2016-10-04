using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TaskTwo
{
    public class Resourses
    {
        private BigInteger souls = 0;
        private BigInteger food = 0;
        private BigInteger deadlocks = 0;


       public Resourses()
        {
            this.Souls = 0;
            this.Food = 0;
            this.Deadlocks = 0;
        }

        public BigInteger Souls
        {
            get
            {
                return this.souls;
            }
            set
            {
                this.souls = value;
            }
        }

        public BigInteger Food
        {
            get
            {
                return this.food;
            }
            set
            {
                this.food = value;
            }
        }
        public BigInteger Deadlocks
        {
            get
            {
                return this.deadlocks;
            }
            set
            {
                this.deadlocks = value;
            }
        }
    }
}
