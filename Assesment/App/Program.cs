using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Read provided input file
        string[] input;
        FileStream fileStream = new(args[0], FileMode.Open);
        using (StreamReader reader = new(fileStream))
        {
            string text = reader.ReadToEnd();
            input = text.Split(Environment.NewLine);
        }

        // Sorting the names
        Array.Sort(input, new Comparer());

        // Outputting Sorted names to file.
        using (StreamWriter outputFile = new StreamWriter("sorted-names-list.txt"))
        {
            foreach (string line in input){
                outputFile.WriteLine(line);
                Console.WriteLine(line);
            }
        }
    }

    class Comparer : IComparer<string>
    {
        public int Compare(string n1, string n2)
        {
            // Seperate given names and last names for comparison
            string[] one = n1.Split(' ');
            string[] two = n2.Split(' ');

            // Compare Last names then rest of given name
            // Continue looping until one of the names has no more given names
            while(one.Count() * two.Count() != 0){
                string last_one = one.Last();
                string last_two = two.Last();
                one = one.Take(one.Count() - 1).ToArray();
                two = two.Take(two.Count() - 1).ToArray();
                // compare last names first
                int lastNameComparison = string.Compare(last_one, last_two, StringComparison.OrdinalIgnoreCase);
                if (lastNameComparison != 0)
                {
                    return lastNameComparison;
                }
            }
            return string.Compare(n1, n2, StringComparison.OrdinalIgnoreCase);
        }
    }
}