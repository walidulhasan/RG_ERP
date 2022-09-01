using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
  public partial  class DFS_Return_Rolls
    {
        [Key]
        public long ReturnID { get; set; }
        public long IssuanceID { get; set; }
        public string RollNo { get; set; }
        public long RollID { get; set; }
        public string Comments { get; set; }
        public int? Status { get; set; }
        public DateTime? Return_Date { get; set; }
        public DateTime? Recevie_Date { get; set; }
        public long? RecevingID { get; set; }
    }
}
