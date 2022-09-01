using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class VStyleColorSize
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public int SizeSetId { get; set; }
        public int ColorSetId { get; set; }
        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
    }
}
