using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciFgtype
    {
        [Key]
        public int FgtypeId { get; set; }
        public string FgtypeDesc { get; set; }
    }
}
