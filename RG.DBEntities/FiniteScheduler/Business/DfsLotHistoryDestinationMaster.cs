using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsLotHistoryDestinationMaster
    {
        public long Ldid { get; set; }
        public long? Hid { get; set; }
        public long? DestinationLotId { get; set; }
        public string DestinationLotNumber { get; set; }
        public int? DocumentTypeId { get; set; }
        public long? PantoneId { get; set; }
        public DateTime? Date { get; set; }
    }
}
