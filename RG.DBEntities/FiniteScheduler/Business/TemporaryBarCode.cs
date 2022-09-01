using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TemporaryBarCode
    {
        public long Id { get; set; }
        public long? StyleId { get; set; }
        public string ColorCode { get; set; }
        public long? JobId { get; set; }
        public string BarCodeNo { get; set; }
    }
}
