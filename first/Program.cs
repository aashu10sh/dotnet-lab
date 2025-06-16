// See https://aka.ms/new-console-template for more information
//

namespace ReadWriteOnlyProperties
{
    public class Student
    {
        private string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    public class MatrixMultiplication
    {
        public void Run()
        {
            int[,] first = new int[3, 3];
            int[,] second = new int[3, 3];
            int[,] sum = new int[3, 3];

            Console.WriteLine("Please enter your Matrix 1 :");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    first[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("Please enter your Matrix 2 :");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    second[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum[i, j] = first[i, j] + second[i, j];
                }
            }

            Console.WriteLine("Sum: ");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("Sum is: ");
                    Console.WriteLine(sum[i, j]);
                }
            }

        }


    }
    class Program
    {
        public static void Main(string[] args)
        {
            MatrixMultiplication mm = new MatrixMultiplication();
            mm.Run();
        }
    }
}


