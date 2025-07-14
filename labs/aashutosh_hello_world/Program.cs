namespace AashutoshLab
{
    class Runner
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Lab Work of Aashutosh Pudasaini - 1202");

            Lab2.AddByConstructor abc = new Lab2.AddByConstructor(10, 21);
            int sum = abc.Add();
            Console.WriteLine("The sum is {0}", sum);

            Lab3.JaggedArrayLab jal = new Lab3.JaggedArrayLab(
            new int[][]{
                new int[] { 1, 2, 3 },
                new int[] { 4, 5 },
                new int[] { 6, 7, 8, 9 }
            }
            );
            jal.DisplayWithSums();

            int[,] A = {
            {1, 2},
            {3, 4}
            };

            int[,] B = {
            {5, 6},
            {7, 8}
            };


            Lab4.MultiplyMatrix mm = new Lab4.MultiplyMatrix(A, B);
            mm.Multiply();
            mm.DisplayResult();

            Lab5.DiagonalElementsofMatrix dem = new Lab5.DiagonalElementsofMatrix(
                        new int[,] {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        }
            );
            dem.DisplayDiagonalSum();

            Lab6.Square sq = new Lab6.Square(15);
            int area = sq.GetArea();
            Console.WriteLine("Area is {0}", area);

            Lab7.PaintJob pj = new Lab7.PaintJob(10, 13);
            int area_per = pj.GetArea();
            int price_per = pj.CostPerArea(area);

            Console.WriteLine("Area: {0} and Price: {1}", area_per, price_per);

            Lab8.Student balti = new Lab8.Student("Balti", 21, 89);
            balti.Print();

            Lab9.PaintJob pj2 = new Lab9.PaintJob(10, 13);
            Console.WriteLine("Price is ${0}", pj2.CalculatePrice());

            Lab10.Son son = new Lab10.Son();
            son.Breathe();

            Lab11.MulticastOperations operations = new Lab11.MulticastOperations();
            operations.Add(10,10);
            operations.Subtract(2,1);

        }
    }
}
