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

            // constructor
            public InputElement(string rawString)
            {
                // parse raw string
            }
        }

        class Inputs
        {
            private string filePath = String.Empty;

            public List<InputElement> elements = new List<InputElement>();

            public Inputs(string filePath)
            {
                this.filePath = filePath;

                foreach (string row in new StreamReader(filePath).ReadToEnd().Trim().Split('\n'))
                    this.elements.Add(new InputElement(row));
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
