using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblPaymentTerm
    {
        [Key]
        public int Ptid { get; set; }
        public string Ptdescription { get; set; }
        public int CompanyId { get; set; }
        public int? NoOfDays { get; set; }
        public bool? IsDisplay { get; set; }
    }
}
