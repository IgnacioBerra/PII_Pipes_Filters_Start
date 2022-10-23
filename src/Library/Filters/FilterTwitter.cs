using System;
using System.Drawing;
using System.Text;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class FilterTwitter:IFilter
    {
        // "Name" Refiere al nombre de la imagen que subiremos luego a Twitter. Como en los otros filtros, arreglo ese string para que contenga lo necesario para guardar el path. 
        public string Name{get;set;}
        public FilterTwitter(string name)
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
            TwitterImage twImage = new TwitterImage();
            Console.WriteLine(twImage.PublishToTwitter("Agregando filtros a imagenes!", newName));
            return image;
        }
    }




}