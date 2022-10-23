using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;



// En este PIPE llequearemos si la propiedad Cara de los objetos de FilterCognitive es false o true, dependiendo de eso, si se le agrega
// un filtro o otro. 

namespace CompAndDel.Pipes
{
    public class PipeBifurcatedConditional : IPipe
    {
        protected IPipe PipeFalse;
        protected IPipe PipeTrue;

        protected FilterCognitive FilterCognitive;
        
        
        public PipeBifurcatedConditional(IPipe pipeFalse, IPipe pipeTrue, FilterCognitive fCond )
        {
            this.PipeTrue = pipeTrue;
            this.PipeFalse = pipeFalse;
            this.FilterCognitive = fCond;
        }
        public IPipe getPipeFalse
        {
            get { return this.PipeFalse; }
        }
        
        
        public IPipe getPipeTrue
        {

            get { return this.PipeTrue; }
        }

         

        public IPicture Send(IPicture picture)
        {
            this.FilterCognitive.Filter(picture);
            if (FilterCognitive.Cara == true)
            {
                return this.PipeTrue.Send(picture);
            }
            else
            {
                return this.PipeFalse.Send(picture);
            }
          
        }
    }
}

