using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class Greige_PermanentReceivingMaster
    {
        [Key]
        public int PermRecMID { get; set; }
        public DateTime? PermRecDate { get; set; }
        public long? GIMID { get; set; }
        public int? Status { get; set; }
        public string PermRecNo { get; set; }
        public long? YKNCID { get; set; }
    }
}
