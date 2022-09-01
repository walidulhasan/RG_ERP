using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Embro.Setup
{
    public partial class GeneralSetupMaster
    {
        [Key]
        public string SetupID { get; set; }
        public string Description { get; set; }
        public DateTime RDate { get; set; }
    }
}
