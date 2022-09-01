using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
    public class CBM_PrintedChequeStatus
    {
        [Key]
        public long StatusID { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
    }
}
