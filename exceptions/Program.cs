using System;

namespace ExceptionsImplementation
{
    class Program
    {
        public static void Main(string[] args)
        {
            int a = 10;
            int b = 0;
            int x;

            try
            {
                x = a / b;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Caught a DivideByZeroException: " + ex.Message);
            }

            try
            {
                int[] numbers = { 1, 2, 3 };
                Console.WriteLine(numbers[5]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Caught an IndexOutOfRangeException: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("ggs bro");
            }
        }
    }
}
