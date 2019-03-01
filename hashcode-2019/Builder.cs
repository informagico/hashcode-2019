using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashcode_2019
{
    class Builder
    {
        public static Slide[] SlideBuilder(Photo[] photos)
        {
            // separate vertical from horizontal slides
            List<Slide> slides = new List<Slide>();
            List<Photo> verticalPhotos = new List<Photo>();

            int slideIndex = 0;

            foreach (Photo photo in photos)
            {
                if (photo.Orientation == 'V')
                    verticalPhotos.Add(photo);
                else
                {
                    slides.Add(new Slide(photo.Tags, new Tuple<int, int>(photo.Index, -1), slideIndex));
                    slideIndex++;
                }
            }

            // order verticals photo by number of tags
            verticalPhotos = (from q in verticalPhotos orderby q.Tags.Length select q).ToList();

            // create slides with vertical photos HashSet
            for (int i = 0; i < verticalPhotos.Count / 2/*verticalPhotos.Count()*/; i++)
            {
                // TODO: OPTIMIZE COMBINE METHOD

                // *** METHOD #1
                // combine vertical photos as:
                // MOST TAGS + LESS TAGS
                if (verticalPhotos[i].Used)
                    continue;

                verticalPhotos[i].Use();

                //Photo relatedVertical = (from q in verticalPhotos where !q.Used select q).LastOrDefault();
                Photo relatedVertical = verticalPhotos[verticalPhotos.Count - i- 1];

                // create a set of tags
                HashSet<string> tags = new HashSet<string>();

                // add first slide tags
                for (int j = 0; j < verticalPhotos[i].Tags.Length; j++)
                    tags.Add(verticalPhotos[i].Tags[j]);

                if (relatedVertical != null)
                {
                    relatedVertical.Use();
                    //verticalPhotos[randomVerticalPhoto.Index].Use();

                    // add second slide tags
                    for (int j = 0; j < relatedVertical.Tags.Length; j++)
                        tags.Add(relatedVertical.Tags[j]);
                }

                // add slide to the list
                slides.Add(new Slide(tags.ToArray(), new Tuple<int, int>(verticalPhotos[i].Index, (relatedVertical != null ? relatedVertical.Index : -1)), slideIndex));
                slideIndex++;


                // *** METHOD #2
                // TBD
            }

            return slides.ToArray();
        }
    }
}
