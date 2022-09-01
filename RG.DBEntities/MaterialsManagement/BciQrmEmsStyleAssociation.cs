using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciQrmEmsStyleAssociation
    {
        [Key]
        public string Qrmstyle { get; set; }
        public string Emsstyle { get; set; }
        public int? StyleId { get; set; }
    }
}
