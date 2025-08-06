
namespace ExamPractice
{
    abstract class Worker
    {
        public abstract double Work();

        public void PrintStuff()
        {
            Console.WriteLine("Printing Stuff");
        }
    }

    class GameDeveloper : Worker
    {
        public override double Work()
        {
            Console.WriteLine("game dev is working");
            return 2.0;
        }
    }

}