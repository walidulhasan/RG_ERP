using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class KRS_Versions
    {
        [Key]
        public int KRSVID { get; set; }
        public string versionxml { get; set; }
        public int krsid { get; set; }
    }
}
