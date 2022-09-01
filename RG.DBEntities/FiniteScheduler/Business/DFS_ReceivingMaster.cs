using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
  public  class DFS_ReceivingMaster
    {
        public long ID { get; set; }
        public long? DCID { get; set; }
        public long? IssuanceID { get; set; }
        public DateTime? ReceivingDate { get; set; }
        public string UserID { get; set; }
        public string Comments { get; set; }
    }
}
