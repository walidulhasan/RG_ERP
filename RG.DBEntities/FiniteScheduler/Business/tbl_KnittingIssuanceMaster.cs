using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
   public class tbl_KnittingIssuanceMaster
    {
        [Key]
        public long IssuanceID { get; set; }
        public string IssuanceNo { get; set; }
        public DateTime IssuanceDate { get; set; }
    }
}
