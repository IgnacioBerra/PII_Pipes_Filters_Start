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

            FilterAutoSave AutoSave1 = new FilterAutoSave("EditUno");
            FilterAutoSave AutoSave2 = new FilterAutoSave("EditDos");
            FilterGreyscale greyScale = new FilterGreyscale();
            FilterNegative negativeFilter = new FilterNegative();
            PipeNull pipeNull = new PipeNull();
            PipeSerial pipe2 = new PipeSerial(negativeFilter,pipeNull);
            IPicture image2 = pipe2.Send(picture);
            AutoSave2.Filter(image2);
            provider.SavePicture(image2, @"EditLuke1raParte.jpg");
            PipeSerial pipe = new PipeSerial(greyScale,pipe2);
            IPicture image1 = pipe.Send(picture);
            AutoSave1.Filter(image1);

           

        }
    }
}
