using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashcode_2019
{
    class Optimizer
    {
        /// <summary>
        /// Returns count of common tags between slide1 and slide2
        /// </summary>
        /// <param name="slideA"></param>
        /// <param name="slideB"></param>
        /// <returns></returns>
        private static int GetCommonTagsScore(Slide slideA, Slide slideB)
        {
            return slideA.Tags.Intersect(slideB.Tags).Count();
        }

        /// <summary>
        /// Returns count of Tags that are in Slide A but not in Slide B
        /// </summary>
        /// <param name="slideA">Slide A</param>
        /// <param name="slideB">Slide B</param>
        /// <returns></returns>
        private static int GetS1CommonTags(Slide slideA, Slide slideB)
        {
            return slideA.Tags.Length - slideA.Tags.Intersect(slideB.Tags).Count();
        }

        /// <summary>
        /// Get interest score between two slides
        /// </summary>
        /// <param name="slideA"></param>
        /// <param name="slideB"></param>
        /// <returns></returns>
        private static int GetMostInterest(Slide slideA, Slide slideB)
        {
            int[] scores = { GetCommonTagsScore(slideA, slideB), GetS1CommonTags(slideA, slideB), GetS1CommonTags(slideB, slideA) };
            return scores.Min();
        }

        /// <summary>
        /// Returns an array of Slide, optimized by consequential "interest"
        /// </summary>
        /// <param name="slides"></param>
        /// <returns></returns>
        public static /*Tuple<int[], int>*/Slide[] OptimizeSlides(Slide[] slides)
        {
            //List<Slide> slideshow = new List<Slide>();

            int slideShowIndex = 0;

            int[] slideshow = new int[slides.Length];

            // use the first slide in slideshow
            slideshow[slideShowIndex] = slides[0].SlideIndex;
            slides[slideShowIndex].Use();

            // TODO: OPTIMIZE RELATION MATCH METHOD
            List<Slide> sortedSlides = new List<Slide>();
            sortedSlides.AddRange(slides);
            sortedSlides.Sort((a, b) =>
            {
                return GetMostInterest(a, b);
            });

            return sortedSlides.ToArray();
        }
    }
}
