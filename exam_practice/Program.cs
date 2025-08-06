namespace ExamPractice
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FPSGod dude = new FPSGod("Lakpa");
            dude.PrintFragger();

            RastraBank rb = new RastraBank();

            GameDeveloper pranjal = new GameDeveloper();
            pranjal.Work();
            pranjal.PrintStuff();

            InterFaceMan man = new InterFaceMan();
            man.Walk();
            man.Print();

            try
            {
                Voter balti = new Voter("Balti", 14);
                balti.Validate();
            }
            catch (CannotVoteException ex)
            {
                Console.WriteLine($"Wowsers, {ex.Message}");
            }

        }
    }
}