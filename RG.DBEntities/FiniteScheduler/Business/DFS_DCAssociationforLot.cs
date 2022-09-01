using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
   public class DFS_DCAssociationforLot
    {
        public long ID { get; set; }
        [ForeignKey("DFS_LotMakingMaster")]
        public long? LotID { get; set; }
        public long? DCID { get; set; }
        public virtual DFS_LotMakingMaster DFS_LotMakingMaster { get; set; }
    }
}
