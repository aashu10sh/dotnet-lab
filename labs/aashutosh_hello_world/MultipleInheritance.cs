namespace Lab7
{
    interface HasArea
    {
        public int GetArea();
    }
    interface HasCost
    {
        public int CostPerArea(int area);

    }

    class PaintJob : HasArea, HasCost
    {
        public int length;
        public int price;
        public PaintJob(int _length, int _price)
        {
            length = _length;
            price = _price;
        }

        public int GetArea()
        {
            return length * length;
        }

        public int CostPerArea(int area)
        {
            return area * price;
        }

    }

}