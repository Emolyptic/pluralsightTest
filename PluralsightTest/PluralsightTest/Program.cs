using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] testArray = new string[]
                {
                "KittenService: ",
                "Leetmeme: Cyberportal",
                "Cyberportal: Ice",
                "CamelCaser: KittenService",
                "Fraudstream: Leetmeme",
                "Ice: "
                };

            string[] output = createDependencyList(testArray);
        }
        public static string[] createDependencyList(string[] test)
        {
            return test;
        }

    }
}
