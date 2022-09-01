using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class VAgencyWorkCenterLink
    {
        public int WorkCenterId { get; set; }
        public string WorkCenter { get; set; }
        public int MrpitemCode { get; set; }
        public string Mname { get; set; }
    }
}
