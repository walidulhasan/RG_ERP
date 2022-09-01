using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
   public partial class ModelApprovedCost
    {
        public long ID { get; set; }
        [ForeignKey("ModelCosting")]
        public int VersionID { get; set; }
      
        public long StyleID { get; set; }
        public double ApprovedCost { get; set; }
        public int CurrencyID { get; set; }
        public int? IsApproved { get; set; }
        public virtual ModelCosting ModelCosting { get; set; }
    }
}
