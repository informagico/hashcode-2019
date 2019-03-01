using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashcode_2019
{
    class Program
    {
        static string filePath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\data\\";
        static string[] fileNames = { "a_example.txt", "b_lovely_landscapes.txt", "c_memorable_moments.txt", "d_pet_pictures.txt", "e_shiny_selfies.txt" };

        static void Main(string[] args)
        {
            foreach (string fileName in fileNames)
            {
                // parse file
                Photo[] photos = Parser.Parse(filePath + fileName);

                // create slides
                Slide[] slides = Builder.SlideBuilder(photos);

                // generate slideshow
                Slide[] slideshow = Optimizer.OptimizeSlides(slides);

                // save slideshow result
                Parser.Save(filePath + fileName, slideshow);
            }

            Console.WriteLine("DONE!");
            Console.ReadLine();
        }
    }
}
