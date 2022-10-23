using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {

            // SECUENCIA 1  
            // PictureProvider provider = new PictureProvider();
            // IPicture picture = provider.GetPicture(@"luke.jpg");

            // FilterAutoSave AutoSave1 = new FilterAutoSave("EditUno");
            // FilterAutoSave AutoSave2 = new FilterAutoSave("EditDos");
            // FilterGreyscale greyScale = new FilterGreyscale();
            // FilterNegative negativeFilter = new FilterNegative();
            // PipeNull pipeNull = new PipeNull();
            // PipeSerial pipe2 = new PipeSerial(negativeFilter,pipeNull);
            // IPicture image2 = pipe2.Send(picture);
            // AutoSave2.Filter(image2);
            // provider.SavePicture(image2, @"EditLuke1raParte.jpg");
            // PipeSerial pipe = new PipeSerial(greyScale,pipe2);
            // IPicture image1 = pipe.Send(picture);
            // AutoSave1.Filter(image1);


            // SECUENCIA 2 
            FilterAutoSave AutoSave1 = new FilterAutoSave("EditUno");
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            FilterGreyscale greyScale = new FilterGreyscale();
            FilterNegative negativeFilter = new FilterNegative();
            PipeNull pipeNull = new PipeNull();
            IPipe pipeUlt = new PipeSerial(negativeFilter,pipeNull);
            FilterTwitter filterTw= new FilterTwitter("luke");
            IPipe pipePUlt= new PipeSerial(filterTw,pipeNull);
            FilterCognitive fC = new FilterCognitive("luke");
            IPipe pF1 = new PipeBifurcatedConditional(pipeUlt,pipePUlt,fC);
            PipeSerial pipeS1 = new PipeSerial(greyScale,pF1);
            IPicture image1 = pipeS1.Send(picture);
            provider.SavePicture(image1,"Editsssss");
           
           
        }
    }
}
