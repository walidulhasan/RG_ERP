using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblYarntype
    {
        public int YtId { get; set; }
        public string YarnDesc { get; set; }
        public string YarnCode { get; set; }
        public DateTime? YarnCreated { get; set; }
        public long? YarnCreatedBy { get; set; }
    }
}
