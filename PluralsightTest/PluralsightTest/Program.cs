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

            string output = createDependencyList(testArray);

            Console.ReadLine();
        }
        public static string createDependencyList(string[] test)
        {
            List<string> programs = new List<string>();
            List<string> dependents = new List<string>();

            List<string> noEdges = new List<string>();

            string final = "";

            //Create two strings one of programs and one of their dependents
            for (int i = 0; i < test.Length; i++)
            {
                string[] temp = test[i].Split(':');
                programs.Add(temp[0].Trim());
                dependents.Add(temp[1].Trim());

                //Find all that don't have dependents.
                if (temp[1] == " ")
                {
                    noEdges.Add(temp[0]);
                }
            }

            //Look for dependents that are not in the programs
            for (int y = 0; y < dependents.Count(); y++)
            {
                if(!programs.Contains(dependents[y]))
                {
                    noEdges.Add(dependents[y]);
                }
            }

            while(noEdges.Count != 0)
            {
                //Remove from no Edge List
                string popped = noEdges[0];

                //Add to Dependency Final List
                final += popped;

               

            }




                return "done";
        }

    }
}
