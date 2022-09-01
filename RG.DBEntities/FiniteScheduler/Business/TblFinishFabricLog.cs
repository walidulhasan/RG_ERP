using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblFinishFabricLog
    {
        public long Id { get; set; }
        public string OrderNo { get; set; }
        public int? FabricSet { get; set; }
        public string Pantone { get; set; }
        public string Comments { get; set; }
        public DateTime? CommentsDate { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
