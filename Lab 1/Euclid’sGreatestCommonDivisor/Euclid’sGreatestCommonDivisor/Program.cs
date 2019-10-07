using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclid_sGreatestCommonDivisor
{
    class Program
    {

        public static int GCDRecursive(int a, int b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            if (a > b)
                return GCDRecursive(a % b, b);
            else
                return GCDRecursive(a, b % a);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Algorithm run on 20 and 30");
            int result = GCDRecursive(20, 30);
            Console.WriteLine(result);
            Console.WriteLine();

            Console.WriteLine("Algorithm run on 50 and 70");
            result = GCDRecursive(50, 70);
            Console.WriteLine(result);
            Console.WriteLine();

            Console.WriteLine("Algorithm run on 9 and 12");
            result = GCDRecursive(9, 12);
            Console.WriteLine(result);
            Console.WriteLine();

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
