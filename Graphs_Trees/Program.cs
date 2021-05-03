using System;
using System.IO;

namespace Graphs_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();

            StreamReader file = new StreamReader(@"..\..\..\dictionary.txt");
            string word;
            while (!((word = file.ReadLine()) is null))
            {
                // Double check that no duplicates are entered
                if (!tree.Insert(word)) Console.WriteLine("Duplicate entered: " + word);
            }

            file.Close();

            while (true)
            {
                Console.Write("Enter a word to check if it's in the tree: ");
                word = Console.ReadLine();
                Console.WriteLine(tree.Contains(word)
                    ? $"The word you entered, '{word}', is in the tree."
                    : $"The word you entered, '{word}', is not in the tree.");
            }
        }
    }
}