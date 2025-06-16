namespace AbstractClassImplementation
{
    abstract internal class Repository 
    {
        public abstract void create();
        public void find(){}
        public void findMany(){}
        public void delete(){}
        public void update(){}
    }

    internal class UserRepository : Repository {

        public override void create(){
            Console.WriteLine("create");
        }
        public new  void find()
        {
            Console.WriteLine("find");
        }
        
        public new void findMany()
        {
            Console.WriteLine("find many");
        }

        public new void delete(){

            Console.WriteLine("delete");
        }

        public new void update(){
            Console.WriteLine("update");

        }

    }

    class Program
    {
        public static void Main(string[] args)
        {
            UserRepository userRepo = new UserRepository();
            userRepo.create();
        }
    }
    
}