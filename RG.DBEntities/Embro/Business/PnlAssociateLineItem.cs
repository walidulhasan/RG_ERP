using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class PnlAssociateLineItem
    {
        public int Id { get; set; }
        public int? LineId { get; set; }
        public long? CoaId { get; set; }
    }
}
