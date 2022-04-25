using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
    public class Achat
    {
        public DateTime DateAchat { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ClientFK")]
        public virtual Client Client { get; set; }
        public int ClientFK { get; set; }
        [ForeignKey("ProductFK")]
        public virtual Product Product { get; set; }

        public int ProductFK { get; set; }

    }
}
