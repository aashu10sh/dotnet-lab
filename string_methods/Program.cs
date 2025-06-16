namespace StringMethods 
{
    internal class Program
    {
        static void Main(String[] args)
        {
            String message = "Balti,DD,Scamrat";

            foreach (string name in message.Split(","))
            {
                Console.WriteLine(name);
            }

            String string1 = "Hello World!";

            String newString = string1.Replace("Hello","MoshiMosh");
            Console.WriteLine("Old {0}", string1);
            Console.WriteLine("New {0}",newString);

        }
    }

}