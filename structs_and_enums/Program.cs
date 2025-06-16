namespace StructImplmentation
{
    public enum Gender
    {
        Male,
        Female
    }
    public struct User
    {
        public string name;
        public int age;
        public Gender gender;
        public User(string name, int age, Gender gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }
        public void display()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine(age);
            Console.WriteLine(gender);
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            User user = new User("Aaashutosh", 21, Gender.Male);
            user.display();
        }
    }

}