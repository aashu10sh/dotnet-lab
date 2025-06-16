namespace InheritancePlayGround
{
    internal class GrandFather
    {
        public void huntTiger()
        {
            Console.WriteLine("Hunt Tiger");
        }
    }
    internal class Father : GrandFather
    {
        public void huntJackal()
        {
            Console.WriteLine("Hunt Jackal");
        }
    }
    internal class Son : Father
    {
        public void huntBaddie()
        {
            Console.WriteLine("Hunt Baddie");
        }
    }

    class MainProgram
    {
        public static void Main(String[] args)
        {
            Son rashihang = new Son();
            rashihang.huntTiger();
            rashihang.huntJackal();
            rashihang.huntBaddie();
        }
    }
}