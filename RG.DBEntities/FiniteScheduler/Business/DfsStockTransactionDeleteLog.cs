using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsStockTransactionDeleteLog
    {
        public long? Id { get; set; }
        public long? DocumentTypeId { get; set; }
        public long? DocumentNo { get; set; }
        public long? Dcid { get; set; }
        public long? DcattributeInstanceId { get; set; }
        public string FinishingCode { get; set; }
        public long? RollId { get; set; }
        public string RollNo { get; set; }
        public long? NoOfRolls { get; set; }
        public double? Quantity { get; set; }
        public long? StyleId { get; set; }
        public string PantoneNo { get; set; }
        public long? MatchingSourceId { get; set; }
        public long? PantoneId { get; set; }
        public long? StoreLocationId { get; set; }
        public long? Ykncid { get; set; }
        public long? MachineId { get; set; }
        public string LotNo { get; set; }
        public long? UserId { get; set; }
        public string Comments { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
