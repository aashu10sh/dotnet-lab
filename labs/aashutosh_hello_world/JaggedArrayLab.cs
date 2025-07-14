using System;

namespace Lab3
{
    class JaggedArrayLab
    {
        private int[][] jaggedArray;

        public JaggedArrayLab(int[][] inputArray)
        {
            jaggedArray = inputArray;
        }

        public void DisplayWithSums()
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int sum = 0;
                Console.Write("Row {0}: ", i);

                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                    sum += jaggedArray[i][j];
                }

                Console.WriteLine("=> Sum: " + sum);
            }
        }
    }
}
