namespace InterfaceImplementation
{


    interface IShape
    {
        double GetArea();
    }

    interface IColor
    {
        string GetColor();
    }

    class Rectangle : IShape, IColor
    {
        private double width;
        private double height;
        private string color;

        public Rectangle(double width, double height, string color)
        {
            this.width = width;
            this.height = height;
            this.color = color;
        }

        public double GetArea()
        {
            return width * height;
        }

        public string GetColor()
        {
            return color;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {

            Rectangle rectangle = new Rectangle(20, 20, "red");
            Console.WriteLine("Color: " + rectangle.GetColor());
            Console.WriteLine("Area : " + rectangle.GetArea());
        }
    }

}