using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciSingleBarCodes
    {
        [Key]
        public string SingleBarCode { get; set; }
        public int Status { get; set; }
    }
}
