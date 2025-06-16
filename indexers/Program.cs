// See https://aka.ms/new-console-template for more information

namespace IndexerImplementation
{
    internal class IndexerImpl
    {
        private int[] ids = new int[5];

        public int this[int index]
        {
            set
            {
                if (index >= 0 && index < ids.Length)
                {
                    if (value > 0)
                    {
                        ids[index] = value;
                    }
                    else
                    {
                        Console.WriteLine("Id is invalid..");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Id is invalid...");
                    Console.ReadLine();
                }
            }
            get
            {
                return ids[index];
            }
        }
    }

    class Program
    {
        public static void Main(String[] args)
        {
            IndexerImpl indexer = new IndexerImpl();
            indexer[3] = 13;
            Console.WriteLine(indexer[3]);
            Console.ReadLine();
        }
    }
}

