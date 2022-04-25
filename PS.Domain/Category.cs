using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
   public class Category : Concept
    {

        public int CategoryId {get; set;}

        public string Name {get; set;}

        public virtual List<Product> Products {get; set;}

        public override void getDetails()
        {
            throw new NotImplementedException();
        }
    }
}
