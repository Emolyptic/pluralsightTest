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
            //List given in instructions
            string[] validOne = new string[]
                {
                "KittenService: ",
                "Leetmeme: Cyberportal",
                "Cyberportal: Ice",
                "CamelCaser: KittenService",
                "Fraudstream: Leetmeme",
                "Ice: "
                };
            //Short List given in instructions
            string[] validTwo = new string[]
            {
                "KittenService: CamelCaser",
                "CamelCaser: "
            };
            //Large String
            string[] validThree = new string[]
            {
                "Earth: Fire",
                "Fire: Wind",
                "Wind: Water",
                "Water: Heart",
                "Heart: Captain",
                "Captain: Save",
                "Save: "
            };

            //Invalid cycle given in instructions
            string[] invalidOne = new string[]
            {
            "KittenService: ",
            "Leetmeme: Cyberportal",
            "Cyberportal: Ice",
            "CamelCaser: KittenService",
            "Fraudstream: ",
            "Ice: Leetmeme"
            };
            //Invalid list given one entry doesn't have necesary data
            string[] invalidTwo = new string[]
            {
            "KittenService: ",
            "Leetmeme: Cyberportal",
            "Cyberportal: Ice",
            ": KittenService",
            "Fraudstream: Leetmeme",
            "Ice: "
            };
            //Invalid List Empty List
            string[] invalidThree = new string[]
            {
            };
            //Invalid List Program has itself as Dependency
            string[] invalidFour = new string[]
            {
                "KittenService: ",
                "Leetmeme: Ice",
                "Cyberportal: Cyberportal",
                "CamelCaser: KittenService",
                "Fraudstream: Leetmeme",
                "Ice: "
            };
            //Invalid List missing : 
            string[] invalidFive = new string[]
                {
                "KittenService: ",
                "Leetmeme Cyberportal",
                "Cyberportal: Ice",
                "CamelCaser: KittenService",
                "Fraudstream: Leetmeme",
                "Ice: "
                };

            string[] invalidSix = new string[]
                {
                "KittenService: ",
                "Leetmeme: Cyberportal",
                "Leetmeme: Ice",
                "Cyberportal: Ice",
                "CamelCaser: KittenService",
                "Fraudstream: Leetmeme",
                "Ice: "
                };

            //Run Tests
            readOutput(createDependencyList(validOne));
            readOutput(createDependencyList(validTwo));
            readOutput(createDependencyList(validThree));

            readOutput(createDependencyList(invalidOne));
            readOutput(createDependencyList(invalidTwo));
            readOutput(createDependencyList(invalidThree));
            readOutput(createDependencyList(invalidFour));
            readOutput(createDependencyList(invalidFive));
            readOutput(createDependencyList(invalidSix));

            Console.ReadLine();

        }

        public static void readOutput(string x)
        {
            Console.WriteLine(x);
            Console.WriteLine("\n");
        }
        public static string createDependencyList(string[] test)
        {
            //Empty Test
            if(test.Length == 0)
            {
                return "ERROR: Invalid Empty List";
            }
            List<node> graph = new List<node>();
            List<string> noDep = new List<string>();
            string final = "";

            //Create two strings one of programs and one of their dependents
            for (int i = 0; i < test.Length; i++)
            {
                //Validate string
                if(!test[i].Contains(':'))
                {
                    return "ERROR: String does not contain ':' separator";
                }

                //
                //SPLIT ARRAY
                //
                string[] temp = test[i].Split(':');

                //Error check if no program has been entered making entry invalid
                if(temp[0].Trim() == "")
                {
                    return "ERROR: Program not found. Fix List";
                }

                //Find all that don't have dependents. Else add them to our graph
                if (temp[1].Trim() == "")
                {
                    noDep.Add(temp[0].Trim());
                }
                else
                {
                    graph.Add(new node(temp[0].Trim(), temp[1].Trim()));
                }

                //Check if multiple programs of same name are found
                if (graph.Count(x => x.program == temp[0]) > 1)
                {
                    return "ERROR: Multiple programs with different dependencies found";
                }

                
            }

            

            while(noDep.Count != 0)
            {
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
                return "ERROR: DEPENDENCY CYCLES";
            }
            final =  final.Substring(0, (final.Length - 2));
            return final;
        }

    }
}
