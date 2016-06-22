using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkThree
{
    public class Student
    {         //FN, Tel, Email, Marks (a List), GroupNumber.
        private string firstName;
        private string lastName;
        private int age;
        private string fN;
        private string tel;
        private string email;
        private List<int> marks ;
        private int groupNumber;

        public Student(string FirstName, string LastName, int Age , string FN = "", string Tel = "", string Email = "", int GroupNumber = 0, List<int> Marks = default(List<int>)) 
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.age = Age;
            this.fN = FN;
            this.tel = Tel;
            this.email = Email;
            this.marks  = new List<int>();
            this.groupNumber = GroupNumber;
        }
        
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }

        public string FN
        {
            get
            {
                return this.fN;
            }

            set
            {
                this.fN = value;
            }
        }

        public string Tel
        {
            get
            {
                return this.tel;
            }

            set
            {
                this.tel = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }

            set
            {
                this.groupNumber = value;
            }
        }

        public List<int> Marks
        {
            get
            {
                return this.marks;
            }
        }


        public void AddMark(int mark)
        {
            this.marks.Add(mark);
        }
    }
}
