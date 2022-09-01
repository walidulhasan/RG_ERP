using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PalleteBuyerAssociationSetup
    {
        public int Id { get; set; }
        public int? BuyerId { get; set; }
        public int? PalleteId { get; set; }
    }
}
