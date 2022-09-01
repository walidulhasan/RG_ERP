using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Embro.Business
{
    public partial class GeneralParameters
    {
        [Key]
        public int ParamID { get; set; }
        public string GeneralDecription { get; set; }
        public long? AccountID { get; set; }
        public int? CompanyId { get; set; }
        public string OtherDesc { get; set; }
    }
}
