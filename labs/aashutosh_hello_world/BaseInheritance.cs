
namespace Lab8
{
    class Person
    {
        private string name;
        private int age;

        protected Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        protected void Print()
        {
            Console.WriteLine($"Name: {this.name}, Age: {this.age}");
        }
    }

    class Student : Person
    {
        private int grade;

        public Student(string name, int age, int grade) : base(name, age)
        {
            this.grade = grade;
        }

        public new void  Print()
        {
            base.Print();
            Console.WriteLine($"Grade: {this.grade}");
        }
    }
}