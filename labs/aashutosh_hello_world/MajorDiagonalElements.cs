using System;

namespace Lab5
{
    class DiagonalElementsofMatrix
    {
        private int[,] matrix;
        private int size;

        // Constructor accepting a square matrix
        public DiagonalElementsofMatrix(int[,] inputMatrix)
        {
            if (inputMatrix.GetLength(0) != inputMatrix.GetLength(1))
                throw new ArgumentException("Matrix must be square.");

            matrix = inputMatrix;
            size = matrix.GetLength(0);
        }

        // Method to calculate the sum of major diagonal elements
        public int GetMajorDiagonalSum()
        {
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrix[i, i];
            }
            return sum;
        }

        // Method to display the result
        public void DisplayDiagonalSum()
        {
            Console.WriteLine("Sum of major diagonal elements: " + GetMajorDiagonalSum());
        }
    }
}
