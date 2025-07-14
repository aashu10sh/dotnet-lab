namespace Lab2
{
    class AddByConstructor
    {
        private int a;
        private int b;
        public AddByConstructor(int _a, int _b)
        {
            a = _a;
            b = _b;
        }

        public int Add()
        {
            return a + b;
        }

    }

}

