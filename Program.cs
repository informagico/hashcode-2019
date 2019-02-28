using System;
using System.Collections.Generic;
using System.IO;

namespace hashcode19
{
    class Program
    {
        class InputElement
        {
            // properties
            char orientation = '-';
            int count = 0;

            List<string> tags = new List<string>();

            // constructor
            public InputElement(string rawString)
            {
                // parse raw string
                string[] splitted = rawString.Split(' ');
                this.orientation = Convert.ToChar(splitted[0]);
                this.count = Convert.ToInt32(splitted[1]);
                for (int i = 0; i < Convert.ToInt32(splitted[1]); i++)
                    this.tags.Add(splitted[2 + i]);
            }
        }

        class Inputs
        {
            private string filePath = String.Empty;

            public int count = 0;

            public Inputs(string filePath)
            {
                this.filePath = filePath;

                List<InputElement> elements = new List<InputElement>();

                string[] rows = new StreamReader(filePath).ReadToEnd().Trim().Split('\n');

                this.count = Convert.ToInt32(rows[0]);

                for (int i = 1; i < rows.Length; i++)
                    elements.Add(new InputElement(rows[i]));
            }

            public void SaveToFile()
            {
                // TODO: save data in required format
                StreamWriter sw = new StreamWriter(Path.ChangeExtension(filePath, ".out"));

                sw.Close();
            }
        }

        static void Main(string[] args)
        {
            // * parse input file
            Inputs inputs = new Inputs("input-A.in");
            // Inputs inputs = new Inputs("input-B.in");
            // Inputs inputs = new Inputs("input-C.in");
            // Inputs inputs = new Inputs("input-D.in");


            // TODO: do some stuff with data


            // save result
            inputs.SaveToFile();

            Console.WriteLine("*** done! ***");
        }
    }
}
