using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmModelRequistionRequirementTemp
    {
        public int Mrrid { get; set; }
        public int ObjectId { get; set; }
        public long AttributeInstanceId { get; set; }
        public int MrpitemCode { get; set; }
        public double Gross { get; set; }
        public int ModelId { get; set; }
        public int? ColorSetId { get; set; }
        public int? SizeSetId { get; set; }
        public int? AdditionalQuantity { get; set; }
    }
}
