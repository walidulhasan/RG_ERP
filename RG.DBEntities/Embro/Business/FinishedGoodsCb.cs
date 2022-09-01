using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class FinishedGoodsCb
    {
        public int Id { get; set; }
        public DateTime? DateOfCb { get; set; }
        public double? ClosingBalance { get; set; }
        public int? AddLine { get; set; }
    }
}
