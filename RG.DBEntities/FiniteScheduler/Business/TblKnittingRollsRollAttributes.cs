using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingRollsRollAttributes
    {
        public long RollAttrId { get; set; }
        public long? RollId { get; set; }
        public int? RollAttrSetupId { get; set; }
        public int? RollAttrValue { get; set; }
        public string RollAttrDesc { get; set; }
    }
}
