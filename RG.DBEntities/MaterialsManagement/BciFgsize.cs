using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciFgsize
    {
        [Key]
        public int FgtypeId { get; set; }
        public int SizeId { get; set; }
        public string SizeDesc { get; set; }
        public int? SortOrder { get; set; }
    }
}
