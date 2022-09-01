using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciQrmEmsColorAssociation
    {
        [Key]
        public string Emscolor { get; set; }
        public string Qrmcolor { get; set; }
    }
}
