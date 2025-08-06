interface Walkable
{
    void Walk();
}

interface Printable
{
    void Print();
}


namespace ExamPractice
{
    class InterFaceMan : Walkable, Printable
    {
        public void Walk()
        {
            Console.WriteLine("Interface man walks");
        }

        public void Print()
        {
            Console.WriteLine("Interface man prints");
        }
    }
}