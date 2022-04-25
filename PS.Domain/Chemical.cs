using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
  public  class Chemical : Product
    {
        
        public string LabName {get; set;}

        public Adress Adress { get; set; }
        public override void GetMyName()
        {
            base.GetMyName();
            Console.WriteLine("chimique");
        }

    }

    
}

