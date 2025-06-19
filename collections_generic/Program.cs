using System.Collections;


namespace GenericImplementation
{
    class Program
    {
        public static void Main(String[] args)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add("Hello ");
            arrayList.Add("World");
            arrayList.Add(" !");

            Console.WriteLine("Count is : " + arrayList.Count);

            foreach (string msg in arrayList)
            {
                Console.Write("   {0}", msg);
                Console.WriteLine();
            }

            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(69, "rashihang");
            dict.Add(31, "yujon");
            dict.Add(21, "balti");

            foreach (KeyValuePair<int, string> pair in dict)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }
        }
    }

}

