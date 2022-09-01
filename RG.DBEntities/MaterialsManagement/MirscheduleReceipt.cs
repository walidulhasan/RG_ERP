using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MirscheduleReceipt
    {
        [Key]
        public int MrpitemCode { get; set; }
        public long AttributeInstanceId { get; set; }
        public int DayId { get; set; }
        public double Quantity { get; set; }
        public long? CollectionId { get; set; }
        public long? OrderId { get; set; }
        public long? StyleId { get; set; }
        public byte? IsDeleted { get; set; }
    }
}
