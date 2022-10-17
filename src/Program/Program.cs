using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            FilterGreyscale greyScale = new FilterGreyscale();
            FilterNegative negativeFilter = new FilterNegative();
            PipeNull pipeNull = new PipeNull();
            PipeSerial pipe2 = new PipeSerial(negativeFilter,pipeNull);
            PipeSerial pipe = new PipeSerial(greyScale,pipe2);
           
        
            IPicture image = pipe.Send(picture);
            provider.SavePicture(image, @"EditLuke.jpg");

            


            
            provider.SavePicture(image, @"PathToImageToSave.jpg");
        }
    }
}
