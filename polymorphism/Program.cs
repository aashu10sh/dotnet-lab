// See https://aka.ms/new-console-template for more information

namespace PolyMorphismImplementation {

    // Run-Time
    class MethodOverLoading {

        public void PrintName(string name, int age)
        {
            Console.WriteLine("Name :" + name + " Age : " + age);
        }

        public void PrintName(string name)
        {
            Console.WriteLine("Name: " + name);
        }
    }

    namespace OverRiding
    {
        class Daddy 
        {

            public void SayJoke()
            {
                

            }

        }


    }



    class MainProgram{
        public static void Main(string[] args)
        {
            MethodOverLoading methodOverLoading = new MethodOverLoading();
            methodOverLoading.PrintName("Yujon", 21);
            methodOverLoading.PrintName("Balti");
        }
    }

}
