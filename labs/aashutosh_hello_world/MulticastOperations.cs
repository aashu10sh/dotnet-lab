using System;

namespace Lab11
{
    public delegate void Operation(int a, int b);

    class MulticastOperations
    {
        public void Add(int a, int b)
        {
            Console.WriteLine("Sum: " + (a + b));
        }

        public void Subtract(int a, int b)
        {
            Console.WriteLine("Difference: " + (a - b));
        }

        public Operation GetMulticastDelegate()
        {
            Operation op = Add;
            op += Subtract;
            return op;
        }
    }
}