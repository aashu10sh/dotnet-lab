namespace JaggedArray
{

    internal class Program
    {
        public static void Main(String[] args)
        {

            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = new int[] { 1, 2 };
            jaggedArray[1] = new int[] { 3, 4, 5 };
            jaggedArray[2] = new int[] { 6, 7, 8, 9 };


            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write("Row: " + i + ": ");
                foreach (int item in jaggedArray[i])
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }

        }
    }

}