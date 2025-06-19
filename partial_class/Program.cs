namespace PartialClassDemo
{
    public partial class Products
    {
        public void method1()
        {
            Console.WriteLine("method 1 called from partial 1 class");
        }
        
    }

    public partial class Products
    {
        public void method2()
        {
            Console.WriteLine("method 2 called from partial 2 class");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Products prod = new Products();
            prod.method1();
            prod.method2();
            Console.ReadLine();
        }
    }
}