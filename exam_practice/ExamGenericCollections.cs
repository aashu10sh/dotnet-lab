using System.Collections.Generic;
public delegate void Notify();

namespace ExamPractice
{
    class MorningStudy<T>
    {
        public T Stuff;

        public MorningStudy(T _t)
        {
            Stuff = _t;
        }

        public void PrintStuffT()
        {
            Console.WriteLine($"Value of stuff is {this.Stuff}");
        }
    }

    class MorningStudyCollectionStuff
    {
        public void DemonstrateLists()
        {
            List<int> numbers = new List<int>();
            numbers.Add(2);
            numbers.Add(2);
            numbers.Add(37);
            numbers.Add(21);

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

        }

        public void DeleGateDemo()
        {
            Notify adelegate = NotifyPerson;

            adelegate();

        }

        public static void NotifyPerson()
        {
            Console.WriteLine("Notifying Person");
            
        }
    }
}