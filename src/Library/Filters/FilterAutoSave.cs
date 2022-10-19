using System;
using System.Drawing;
using System.Text;

namespace CompAndDel.Filters
{
    public class FilterAutoSave:IFilter
    {   
        private string Name{get;set;}
        public FilterAutoSave(string name)
        {
            this.Name=name;
        }
        public IPicture Filter (IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name);
            sb.Append(".jpg");
            string newName = sb.ToString();
            provider.SavePicture(image,newName);
            return image;
        }
    }
}