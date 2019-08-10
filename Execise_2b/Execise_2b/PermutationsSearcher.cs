using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Execise_2b
{
    class PermutationsSearcher
    {
        Dictionary<string, ArrayList> permutationsDic;
        public PermutationsSearcher()
        {
            permutationsDic = new Dictionary<string, ArrayList>();         
        }

        //Read the file and upload it to the Dictionary, then print the strings to the screen.
        public void ReadFromFile()
        {
            string line;
            // Read the file line by line and insert the strings to the dictionary.
            StreamReader file = new StreamReader("./data.txt");
            while ((line = file.ReadLine()) != null)
            {
                InsertStringsToDic(line);
            }            
            file.Close();            
        }

        public void ExecuteSearch(string input) {
            //print all the match strings
            PrintAllEquals(input);
        }

        //map all the string to key - is sorted string values- all the match strings
        public void InsertStringsToDic(string s)
        {
            //sort the string from the file
            char[] characters = s.ToArray();
            Array.Sort(characters);
            string sortedString = new string(characters);

            //if the Dictionary contains the string add it to the Arraylist values
            if(permutationsDic.ContainsKey(sortedString))
                permutationsDic[sortedString].Add(s);
            else
            {
                //else add the string to new ArrayList in the values
                ArrayList stringsEqualsList = new ArrayList();
                stringsEqualsList.Add(s);
                permutationsDic.Add(sortedString, stringsEqualsList);
            }
        }

        //in o(1) we can take the input and print it to the string because we have the dictionary with the sorted string in the key
        public void PrintAllEquals(string input)
        {
            //sort the input string
            char[] characters = input.ToArray();
            Array.Sort(characters);
            string sortedString = new string(characters);

            //if the dictionary contains the sortedString print all the ArrayList in the value of the sorted string in the key of the Dictionary
            if (permutationsDic.ContainsKey(sortedString))
            {
                Console.WriteLine("The matches are:");
                for (int i=0; i<permutationsDic[sortedString].Count; i++)
                {
                    Console.WriteLine(permutationsDic[sortedString][i]);
                }
            }
            else
            {
                Console.WriteLine("There is no match!");
            }
        }
    }
}
