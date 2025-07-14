namespace Lab6
{
    class HasArea
    {
        public virtual int GetArea()
        {
            return 0;
        }
    }

    class Square : HasArea
    {
        public int length;

        public Square(int _length)
        {
            length = _length;
        }

        public override int GetArea()
        {
            return length * length;
        }
    }

}