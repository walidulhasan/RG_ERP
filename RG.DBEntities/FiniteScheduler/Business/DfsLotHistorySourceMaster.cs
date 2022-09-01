using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsLotHistorySourceMaster
    {
        public long Lsid { get; set; }
        public long? Hid { get; set; }
        public long? SourceLotId { get; set; }
        public string SourceLotNumber { get; set; }
        public int? DocumentTypeId { get; set; }
        public long? PantoneId { get; set; }
        public DateTime? Date { get; set; }
    }
}
