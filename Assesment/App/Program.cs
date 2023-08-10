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

        

        // Outputting Sorted names to file.
        using (StreamWriter outputFile = new StreamWriter("sorted-names-list.txt"))
        {
            foreach (string line in input)
                outputFile.WriteLine(line);
        }
    }
}