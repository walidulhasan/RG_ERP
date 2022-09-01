using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Setup
{
    public partial class GeneralSetupDetail
    {
        [Key,Column(Order =0)]
        public string SetupID { get; set; }
        [Key, Column(Order = 1)]
        public string InstanceID { get; set; }
        [Key, Column(Order = 2)]
        public int CompanyID { get; set; }
        public string InstanceValue { get; set; }
        public string Description { get; set; }
        public DateTime RDate { get; set; }
    }
}
