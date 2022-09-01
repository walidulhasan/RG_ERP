using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MaterialInspectionMaster
    {
        public int Id { get; set; }
        public int MinspectionMid { get; set; }
        public DateTime InspectionDate { get; set; }
    }
}
