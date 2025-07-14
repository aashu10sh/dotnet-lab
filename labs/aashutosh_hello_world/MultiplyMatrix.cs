using System;

namespace Lab4
{
    class MultiplyMatrix
    {
        private int[,] matrixA;
        private int[,] matrixB;
        private int[,] result;
        private int m;
        private int n;
        private int p;

        public MultiplyMatrix(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0))
                throw new ArgumentException("Number of columns of Matrix A must match number of rows of Matrix B.");

            matrixA = a;
            matrixB = b;
            m = a.GetLength(0);
            n = a.GetLength(1);
            p = b.GetLength(1);

            result = new int[m, p];
        }

        public void Multiply()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }
        }

        public void DisplayResult()
        {
            Console.WriteLine("Result of Matrix Multiplication:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    Console.Write(result[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
