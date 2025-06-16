// See https://aka.ms/new-console-template for more information

namespace VirtualAndOverrideExample
{
    public class BaseClass
    {
        public virtual int display(int a, int b)
        {
            return a + b;
        }

    }

    public class DerivedClass : BaseClass
    {
        public override int display(int a, int b)
        {
            return (a + b) * 2;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            DerivedClass dc = new DerivedClass();
            Console.WriteLine(dc.display(1, 2));
        }
    }
}
