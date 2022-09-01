using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblLayoutEmpProductionEntry
    {
        public long Id { get; set; }
        public long? ClhId { get; set; }
        public long? ProductionQty { get; set; }
        public long? Defectid { get; set; }
        public long? DefectQty { get; set; }
        public long? Losttime { get; set; }
        public string Remarks { get; set; }
        public long? Userid { get; set; }
        public DateTime? Creationdate { get; set; }
        public long? Workid { get; set; }
        public long? Alterqty { get; set; }
    }
}
