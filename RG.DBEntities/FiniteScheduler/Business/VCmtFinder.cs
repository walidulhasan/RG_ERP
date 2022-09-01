using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class VCmtFinder
    {
        public int WorkCenterId { get; set; }
        public string WorkCenter { get; set; }
        public int MrpitemCode { get; set; }
        public string Mname { get; set; }
        public int StyleId { get; set; }
        public string AssignedStyleNo { get; set; }
        public int OrderId { get; set; }
        public string AssignedOrderNo { get; set; }
    }
}
