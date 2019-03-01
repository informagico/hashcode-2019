using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashcode_2019
{
    class Photo
    {
        public int Index { get; }
        public char Orientation { get; }
        public bool Used { get; private set; }
        public string[] Tags { get; private set; }
        public int TagsCount => Tags.Length;

        public Photo(char orientation, string[] tags, int id)
        {
            this.Used = false;
            this.Orientation = orientation;
            this.Tags = tags;
            this.Index = id;
        }

        public void Use()
        {
            this.Used = true;
        }
    }
}
