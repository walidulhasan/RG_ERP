using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblLotdelweight
    {
        [Key]
        public long Irmlotdelwtid { get; set; }
        public long? Irmlotdelreqid { get; set; }
        public double? Irmlotdelwt { get; set; }
        public DateTime? Irmlotdelwtdate { get; set; }
    }
}
