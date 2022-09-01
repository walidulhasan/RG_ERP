using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsReturnFromFloor
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public long CuttingJobId { get; set; }
    }
}
