using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightTest
{
    public class Node
    {
        public string program;
        public string dependency;
        public Node(string pro, string dep)
        {
            program = pro;
            dependency = dep;
        }
    }
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

            //Test
            // Cycle;
            // Large Cycle;
            // Doesn't have a program before the :
            // One element
            // 

            string output = createDependencyList(testArray);

            Console.ReadLine();
        }
        public static string createDependencyList(string[] test)
        {
            //Dictionary<string, string> dependencies = new Dictionary<string, string>();
            //List<string> programs = new List<string>();
            //List<string> dependents = new List<string>();
            List<Node> graph = new List<Node>();

            List<string> noDep = new List<string>();

            string final = "";

            //Create two strings one of programs and one of their dependents
            for (int i = 0; i < test.Length; i++)
            {
                string[] temp = test[i].Split(':');
             
                //Find all that don't have dependents.
                if (temp[1].Trim() == " ")
                {
                    noDep.Add(temp[0].Trim());
                }
                else
                {
                    graph.Add(new Node(temp[0].Trim(), temp[1].Trim()));
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

            while(noDep.Count != 0)
            {
                //Grab front string from no Edge List
                string popped = noDep[0];
                noDep.Remove(popped);

                //Add to Dependency Final List
                final += popped;

                foreach(Node x in graph)
                {
                    //Go through graph and find those that have a dependency on the popped 
                    if(x.dependency == popped)
                    {
                        noDep.Add(x.program);
                        graph.Remove(x);
                    }
                }
            }

            


                return "done";
        }

    }
}
