namespace OOPHomeworkTwo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // Имплементация на генерикЛист
    public class GenericList<T> where T : IComparable<T>
    {
        private T[] elements;
        private int index;
        
        public GenericList(int capacity)
        {
            this.elements = new T[capacity];
            this.index = 0;
        }

        public void Add(T element)
        {
            this.elements[this.index] = element;
            this.index++;
            
            if (this.index == this.elements.Length)
            {
                T[] copyElements = new T[this.elements.Length * 2];
                for (int i = 0; i < this.elements.Length; i++)
                {
                    copyElements[i] = this.elements[i];
                }

                this.elements = copyElements;
            }
        }

        public T TakeAtIndex(int index)
        {
            return this.elements[index];
        }

        public void RemoveAtIndex(int index)
        {
            for (int i = index; i < this.elements.Length - 2; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.elements[this.elements.Length - 1] = default(T);
        }

        public void InsertAtIndex(T element, int index)
        {
            var oldArray = (T[])this.elements.Clone();
            this.index = 0;
            this.Clear();

            for (int i = 0; i < index - 1; i++)
            {
                this.Add(oldArray[i]);
            }

            this.Add(element);

            for (int i = index + 1; i < oldArray.Length; i++)
            {
                this.Add(oldArray[i - 1]);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                this.elements[i] = default(T);
            }
        }

        public int Find(T element)
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.elements.Length; i++)
            {
                result.Append(this.elements[i]);
                result.Append(" ");
            }

            return result.ToString();
        }
        
        public T Min<t>() where t : IComparable<T>
        {
            T minElement = this.elements[0];

            for (int i = 0; i < this.elements.Length; i++)
            {
                if (minElement.CompareTo(this.elements[i]) > 0)   // !!!
                {
                    minElement = this.elements[i];
                }
            }

            return minElement;
        }

        public T Max<t>() where t : IComparable<T>
        {
            T maxElement = this.elements[0];

            for (int i = 0; i < this.elements.Length; i++)
            {
                if (maxElement.CompareTo(this.elements[i]) < 0)   // !!!
                {
                    maxElement = this.elements[i];
                }
            }

            return maxElement;
        }
    }
}
