using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DailyCuttingReportComments
    {
        public int OrderId { get; set; }
        public int? OrderNo { get; set; }
        public int? StyleId { get; set; }
        public int? ColorId { get; set; }
        public string Comments { get; set; }
        public string ReportDate { get; set; }
    }
}
