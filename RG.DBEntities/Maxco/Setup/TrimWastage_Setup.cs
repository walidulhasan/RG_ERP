using RG.DBEntities.Maxco.Trims;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class TrimWastage_Setup
    {
        public int ID { get; set; }
        public int MRPItemCode { get; set; }
        public double Wastage { get; set; }
        public bool? IsEffected { get; set; }
        public int? ProcurementSourceID { get; set; }

        public virtual Trim_Setup Trim_Setup { get; set; }
    }
}
