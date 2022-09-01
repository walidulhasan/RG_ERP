using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class PnlAssociateCogsItem
    {
        public int Id { get; set; }
        public long? AccountId { get; set; }
        public int? CogsLineId { get; set; }
    }
}
