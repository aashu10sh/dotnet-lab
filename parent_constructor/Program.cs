namespace BaseKeyWordExample
{
    public class BaseKeyWordClass
    {
        public BaseKeyWordClass(int rand)
        {
            Console.WriteLine("The Random Number is :" + rand);
        }

        public string goatedName = "Balti";

        public void display()
        {
            Console.WriteLine("Goated Name: {0}", goatedName);
        }

    }

    public class DerivedKeywordClass : BaseKeyWordClass
    {
        public DerivedKeywordClass(int randomNumber) : base(randomNumber)
        {

        }

        public new void display()
        {
            base.display();
            Console.WriteLine("derived class display called");
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            DerivedKeywordClass derived = new DerivedKeywordClass(31);
            derived.display();
        }
    }
}