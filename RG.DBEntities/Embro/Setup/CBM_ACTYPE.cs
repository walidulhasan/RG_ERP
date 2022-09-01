using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Setup
{
    public partial class CBM_ACTYPE
    {
        public int ID { get; set; }
        public decimal ACTypeID { get; set; }
        public string ACTypeName { get; set; }
        public string ACTypeComments { get; set; }

        public virtual BasicCOA BasicCOA { get; set; }
    }
}
