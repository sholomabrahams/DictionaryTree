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

            Console.WriteLine(tree.Contains("Precocious"));
            Console.WriteLine(tree.Contains("Supercalifragilisticexpialidocious"));
        }
    }
}