using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightTest
{
    public class node 
    {
        public string program;
        public string dependency;
        public node(string pro, string dep)
        {
            program = pro;
            dependency = dep;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] validOne = new string[]
                {
                "KittenService: ",
                "Leetmeme: Cyberportal",
                "Cyberportal: Ice",
                "CamelCaser: KittenService",
                "Fraudstream: Leetmeme",
                "Ice: "
                };

            string[] invalidOne = new string[]
            {
            "KittenService: ",
            "Leetmeme: Cyberportal",
            "Cyberportal: Ice",
            "CamelCaser: KittenService",
            "Fraudstream: ",
            "Ice: Leetmeme"
            };
            
            //Test
            // Cycle;
            // Large Cycle;
            // Doesn't have a program before the :
            // One element
            // 

            string output = createDependencyList(validOne);

            Console.Write(output);
            Console.ReadLine();
        }
        public static string createDependencyList(string[] test)
        {
            //Dictionary<string, string> dependencies = new Dictionary<string, string>();
            //List<string> programs = new List<string>();
            //List<string> dependents = new List<string>();
            List<node> graph = new List<node>();

            List<string> noDep = new List<string>();

            string final = "";

            //Create two strings one of programs and one of their dependents
            for (int i = 0; i < test.Length; i++)
            {
                string[] temp = test[i].Split(':');
             
                //Find all that don't have dependents.
                if (temp[1].Trim() == "")
                {
                    noDep.Add(temp[0].Trim());
                }
                else
                {
                    graph.Add(new node(temp[0].Trim(), temp[1].Trim()));
                }
            }

            //Look for dependents(values) that are not in the programs
            // foreach(Node entry in graph)
            //{
            //    if(!graph.Contains(.ContainsKey(entry.Value))
            //     {
            //         noEdges.Add(entry.Value);
            //         dependencies.Remove(entry.Key);
            //     }
            // }
            Console.WriteLine(noDep.Count);
            while(noDep.Count != 0)
            {
                Console.Write(noDep.Count);
                Console.Write("\n");
                //Grab front string from no Edge List
                string popped = noDep[0];
                noDep.Remove(popped);

                //Add to Dependency Final List
                final = final + popped + ", ";

                for(int q = 0; q < graph.Count(); q++)
                {
                    if(graph[q].dependency == popped)
                    {
                        noDep.Add(graph[q].program);
                        graph.Remove(graph[q]);
                        q--;
                    }
                }
            }

            if(graph.Count > 0)
            {
                Console.WriteLine(final);
                Console.WriteLine("\n");
                Console.WriteLine(graph.Count);
                return "ERROR: DEPENDENCY CYCLES";
            }


                return final;
        }

    }
}
