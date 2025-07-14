
namespace Lab9
{
    class Square
    {
        protected int length;

        public Square(int length)
        {
            this.length = length;
        }

        protected int GetArea()
        {
            return this.length * this.length;
        }
    }

    class PaintJob : Square
    {
        private int price;
        public PaintJob(int length, int price) : base(length)
        {
            this.price = price;
        }

        public int CalculatePrice()
        {
            return this.price * base.GetArea();
        }
        
    }
    
}

