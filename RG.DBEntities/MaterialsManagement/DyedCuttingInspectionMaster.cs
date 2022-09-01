using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedCuttingInspectionMaster
    {
        public long Ciid { get; set; }
        public long CuttingId { get; set; }
        public string Cinsno { get; set; }
        public DateTime InspectionDate { get; set; }
        public int Crnstatus { get; set; }
    }
}
