using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
  public  class DFS_StockTransaction
    {
        [Key]
        public long ID { get; set; }
        public long? DocumentTypeID { get; set; }
        public long? DocumentNo { get; set; }
        public long? DCID { get; set; }
        public long? DCGAttributeInstanceID { get; set; }
        public string FinishingCode { get; set; }
        public long? RollID { get; set; }
        public string RollNo { get; set; }
        public long? NoOfRolls { get; set; }
        public double? Quantity { get; set; }
        public long? StyleID { get; set; }
        public string PantoneNo { get; set; }
        public long? MatchingSourceID { get; set; }
        public long? PantoneID { get; set; }
        public long? StoreLocationID { get; set; }
        public long? YKNCID { get; set; }
        public long? MachineID { get; set; }
        public string rollnonew { get; set; }
        public string rollnop { get; set; }
        public string Comments { get; set; }
        public int? RollStatus { get; set; }
    }
}
