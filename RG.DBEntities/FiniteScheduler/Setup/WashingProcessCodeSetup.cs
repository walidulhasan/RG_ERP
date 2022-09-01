using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingProcessCodeSetup
    {
        public long ProcessId { get; set; }
        public int FabricCategoryId { get; set; }
        public string ProcessName { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public int IsParent { get; set; }
        public long? ParentId { get; set; }
        public byte? Level { get; set; }
        public bool Deleted { get; set; }
    }
}
