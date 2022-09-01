using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
   public class TEMP_Yarn_Issue
    {
        [Key]
        public int RID { get; set; }
        public int? YKNC { get; set; }
        public int AtributeInstanceID { get; set; }
        public int Quantity { get; set; }
        public long? YarnAttributeInstanceID { get; set; }
        public int? WOID { get; set; }
        public long? WOAttributeInstanceID { get; set; }
        public string LotNo { get; set; }
        public DateTime? IssuanceTime { get; set; }
    }
}
