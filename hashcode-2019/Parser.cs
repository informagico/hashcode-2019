using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashcode_2019
{
    class Parser
    {
        public static Photo[] Parse(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                // get file rows
                string[] rows = sr.ReadToEnd().Trim().Split('\n');

                // declare new Photo array
                Photo[] photos = new Photo[int.Parse(rows[0])];
                
                // get every Photo
                for (int i = 1; i < rows.Length; i++)
                {
                    // split row values
                    string[] vals = rows[i].Split();

                    // get orientation
                    char orientation = Char.Parse(vals[0]);

                    // get tags
                    string[] tags = new string[int.Parse(vals[1])];
                    for (int j = 2; j < vals.Length; j++)
                        tags[j - 2] = vals[j];

                    // create new object
                    photos[i - 1] = new Photo(orientation, tags, i - 1);
                }

                return photos;
            }
        }

        public static void Save(string fileName, Slide[] slides)
        {
            StreamWriter sw = new StreamWriter(Path.ChangeExtension(fileName, ".out"));

            // save slideshow slides count
            sw.WriteLine(slides.Count());

            // save slides details
            for (int i = 0; i < slides.Count(); i++)
            {
                //Slide slide = slides[i];
                sw.WriteLine((slides[i].PhotoIndexes.Item1 + " " + (slides[i].PhotoIndexes.Item2 != -1 ? slides[i].PhotoIndexes.Item2.ToString() : "")).Trim());
            }

            // close file
            sw.Close();
        }

        public static void Save(string fileName, Tuple<int[], int> slideshow, Slide[] slides)
        {
            StreamWriter sw = new StreamWriter(Path.ChangeExtension(fileName, ".out"));

            // save slideshow slides count
            sw.WriteLine(slideshow.Item2);

            // save slides details
            for (int i = 0; i < slideshow.Item2; i++)
            {
                Slide slide = slides[slideshow.Item1[i]];
                sw.WriteLine((slide.PhotoIndexes.Item1 + " " + (slide.PhotoIndexes.Item2 != -1 ? slide.PhotoIndexes.Item2.ToString() : "")).Trim());
            }

            // close file
            sw.Close();
        }
    }
}
