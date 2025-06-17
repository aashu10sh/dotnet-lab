namespace MulticastDeligate
{
    public delegate void operation(int x, int y);
    public class Calculation 
    {
        public static void Main(String[] args)
        {
            operation obj = Calculation.Add;
            obj += Calculation.Multiply;
            obj += Calculation.Sub;
            obj(10,5);
            Console.ReadLine();
        }
        public static void Add(int a, int b ){
            Console.WriteLine(a+b);
        }

        public static void  Sub(int a, int b){
            Console.WriteLine(a-b);
        }
        public static void Multiply(int a, int b){
            Console.WriteLine(a*b);
        }
    }

}