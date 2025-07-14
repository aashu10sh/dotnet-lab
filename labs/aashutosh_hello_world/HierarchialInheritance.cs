
namespace Lab10
{
    class GrandFather
    {
        public virtual void Breathe()
        {
        }
    }

    class Father : GrandFather
    {
        public new virtual void Breathe()
        {
        }

    }

    class Son : Father
    {
        public override void Breathe()
        {
            Console.WriteLine("The Sun Breathes");
        }
    }

}

