using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        private List<Student> students;
       
        public Course()
        {
            this.students = new List<Student>();
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public void Join(Student newStudent)
        {
            if (this.students.Count == 30)
            {
                throw new ArgumentOutOfRangeException();
            }

            students.Add(newStudent);
        }

        public void Leave(Student newStudent)
        {
            students.Remove(newStudent);
        }

        public int Count()
        {
            return this.students.Count();
        }
    }
}
