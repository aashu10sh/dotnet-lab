
namespace ExamPractice
{
    class CannotVoteException : Exception
    {
        public CannotVoteException(string _errorMessage, int _age) : base(_errorMessage)
        {
            Console.WriteLine($"Can't vote with {_age}, innit love?");
        }

    }

    class Voter
    {
        public string Name { set; get; }
        public int Age { set; get; }

        public Voter(string _name, int _age)
        {
            Name = _name;
            Age = _age;
        }

        public void Validate()
        {
            if (this.Age < 18)
            {
                throw new CannotVoteException("You are not allowed to vote", this.Age);
            }
        }
    }

}