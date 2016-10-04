using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student
    {
        private static int uniqueNumberSet = 10000;
        private string name;
        private int number;

        public Student(string name)
        {
            this.Name = name;
            this.number = GetUniqueNumber();
           
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get
            {

                return this.number;
            }
        }

        private int GetUniqueNumber()
        {
            if (uniqueNumberSet > 99998)
            {
                throw new ArgumentOutOfRangeException();
            }

            return ++uniqueNumberSet;
        }
    }
}
