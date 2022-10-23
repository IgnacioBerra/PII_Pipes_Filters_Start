using System;
using System.Drawing;
using System.Text;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    public class FilterCognitive:IFilter
    {
        public string Name{get;set;}
        public bool Cara{get;set;}
        public FilterCognitive(string name)
        {
            this.Name = name;
            this.Cara= false;
        }

        public IPicture Filter (IPicture image)
        {
            CognitiveFace cogFace = new CognitiveFace();
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name);
            sb.Append(".jpg");
            string newName = sb.ToString();
            cogFace.Recognize(newName);
            if (!(cogFace.FaceFound==false))
            {
                Cara = true;
            }
            return image;
        }
    }
}