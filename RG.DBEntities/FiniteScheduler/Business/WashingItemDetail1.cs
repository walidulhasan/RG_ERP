using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingItemDetail1
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int ItemId { get; set; }
        public short UnitId { get; set; }
        public bool Deleted { get; set; }
    }
}
