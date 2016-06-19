namespace OOPHomeworkTwo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Matrix<T>
    {
        private T[,] currentMatrix;

        public Matrix(int rows, int cols)
        {
            this.currentMatrix = new T[rows, cols];
        }

        public T[,] matrix
        {
            get
            {
                return this.currentMatrix;
            }

            set
            {
                this.currentMatrix = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                // This indexer is very simple, and just returns or sets
                // the corresponding element from the internal array.
                return this.currentMatrix[row, col];
            }

            set
            {
                if (row > this.currentMatrix.GetLength(0) || row < 0)
                {
                    throw new IndexOutOfRangeException("Row out of range !");
                }

                if (col > this.currentMatrix.GetLength(1) || col < 0)
                {
                    throw new IndexOutOfRangeException("Col out of range !");
                }

                this.currentMatrix[row, col] = value;
            }
        }

        public int RowCount
        {
            get
            {
                return this.currentMatrix.GetLength(0);
            }
        }

        public int ColumnCount
        {
            get
            {
                return this.currentMatrix.GetLength(1);
            }
        }

        public  void PrintMatrix()
        {
            for (int row = 0; row < this.RowCount; row++)
            {
                for (int col = 0; col < this.ColumnCount; col++)
                {
                    Console.Write(this.currentMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if ((first.RowCount != second.RowCount) || (first.ColumnCount != second.ColumnCount))
            {
                throw new ArgumentException("Matrix must be with same size !");
            }

            var result = new Matrix<T>(first.RowCount, second.ColumnCount);
            for (int i = 0; i < first.RowCount; i++)
            {
                for (int j = 0; j < first.ColumnCount; j++)
                {
                    result[i, j] = (dynamic)first[i, j] + second[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if ((first.RowCount != second.RowCount) || (first.ColumnCount != second.ColumnCount))
            {
                throw new ArgumentException("Matrix must be with same size !");
            }

            var result = new Matrix<T>(first.RowCount, second.ColumnCount);
            for (int i = 0; i < first.RowCount; i++)
            {
                for (int j = 0; j < first.ColumnCount; j++)
                {
                    result[i, j] = (dynamic)first[i, j] - second[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if ((first.RowCount != second.ColumnCount) || (first.ColumnCount != second.RowCount))
            {
                throw new ArgumentException("Matrix must be with same size !");
            }
            
            var result = new Matrix<T>(first.RowCount, second.ColumnCount);
            T sum;
            for (int i = 0; i < result.RowCount; i++)
            {
                for (int j = 0; j < result.ColumnCount; j++)
                {
                    sum = (dynamic)0;
                    for (int k = 0; k < first.ColumnCount; k++)
                    {
                        sum += (dynamic)first[i, k] * second[k, j];
                    }

                    result[i, j] = sum;
                }
            }
            return result;
        }

        public  bool IsNonZero()
        {
            for (int row = 0; row < this.RowCount; row++)
            {
                for (int col = 0; col < this.ColumnCount; col++)
                {
                    if (this.currentMatrix[row, col].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
