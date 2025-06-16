namespace MethodOverLoading {
    internal class OverLoading {
        public void displayPerson(string name){
            Console.WriteLine("Name: " + name);
        }
        public` void displayPerson(string name, string age) {
            Console.WriteLine("Name: " + name + " Age: " + age);
        }
    }

    class Program{
        public static void Main(string[] args){
            OverLoading ol = new OverLoading();
            ol.displayPerson("aashutosh");
            ol.displayPerson("Aashutosh", "21");
        }
    }
}