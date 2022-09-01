using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsSupplementaryRequirementSheet
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int StyleId { get; set; }
        public int RejectionId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int Quantity { get; set; }
        public long AttributeInstanceId { get; set; }
        public int Status { get; set; }
    }
}
