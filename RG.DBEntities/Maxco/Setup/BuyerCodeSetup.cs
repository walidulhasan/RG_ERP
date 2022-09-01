using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class BuyerCodeSetup
    {
        public int Id { get; set; }
        public byte BuyerId { get; set; }
        public byte GenderId { get; set; }
        public string Code { get; set; }

        public virtual Buyer_Setup Buyer { get; set; }
        public virtual Gender_Setup Gender { get; set; }
    }
}
