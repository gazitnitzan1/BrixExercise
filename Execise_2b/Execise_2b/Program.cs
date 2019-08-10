using System;

namespace Execise_2b
{
    class Program
    {
        static void Main(string[] args)
        {
            PermutationsSearcher searcher = new PermutationsSearcher();
            searcher.ReadFromFile();

            Console.Write("Enter 5 character string: ");
            string input = Console.ReadLine();
            
            if (input.Length == 5)
                searcher.ExecuteSearch(input);
            else
                Console.Write("You must enter 5 character string, try again!");            
        }       
    }
}
