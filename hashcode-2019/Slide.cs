using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashcode_2019
{
    class Slide
    {
        public int SlideIndex { get; }
        public bool Used { get; private set; }
        public string[] Tags { get; }
        
        public Tuple<int, int> PhotoIndexes { get; }
        
        public Slide(string[] tags, Tuple<int, int> photoIndexes, int slideIndex)
        {
            this.Tags = tags;
            this.PhotoIndexes = photoIndexes;
            this.SlideIndex = slideIndex;
        }

        public void Use()
        {
            this.Used = true;
        }
    }
}
