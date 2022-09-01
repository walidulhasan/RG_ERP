using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MirgrossNet
    {
        [Key]
        public int? ObjectId { get; set; }
        public long AttributeInstanceId { get; set; }
        public int MrpitemCode { get; set; }
        public double Gross { get; set; }
        public int DayId { get; set; }
        public double Net { get; set; }
        public int? PodayId { get; set; }
        public long? ConsolidationAttributeId { get; set; }
        public long? SizeId { get; set; }
        public long? ColorId { get; set; }
        public long? RefNo { get; set; }
    }
}
