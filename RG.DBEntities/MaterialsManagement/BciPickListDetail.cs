using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciPickListDetail
    {
        [Key]
        public long DetailId { get; set; }
        public long OrderId { get; set; }
        public long StyleId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long Qty { get; set; }
        public long PickListId { get; set; }
        public long? SharingDetailId { get; set; }

        public virtual BciPickListMain PickList { get; set; }
    }
}
