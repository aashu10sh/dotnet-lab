using System.IO;

namespace FileHandeling
{
    class Program
    {
        public static void Main(string[] args)
        {
            string fileLocation = "./ggs.txt";
            FileStream fs = null;

            if (File.Exists(fileLocation))
            {
                using (StreamWriter sw = new StreamWriter(fileLocation))
                {
                    sw.Write("Yujon Blud");
                }

                using (StreamReader sr = new StreamReader(fileLocation))
                {
                    Console.WriteLine(sr.Read());
                }
            }
            else
            {
                File.Create(fileLocation);
            }
        }
    }

}