using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WorkCenterMrpitemCode
    {
        public int Id { get; set; }
        public int WorkCenterId { get; set; }
        public int MrpitemCode { get; set; }
    }
}
