using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class PrintedFabricColors
    {
        public int Id { get; set; }
        public long ColorSetId { get; set; }
        public string PantoneNo { get; set; }
        public int DyeingProcessId { get; set; }
        public string ColorName { get; set; }
        public int MatchingSourceId { get; set; }
        public int PalletTypeId { get; set; }
    }
}
