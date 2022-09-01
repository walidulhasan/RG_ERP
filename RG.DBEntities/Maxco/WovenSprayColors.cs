using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class WovenSprayColors
    {
        public int Id { get; set; }
        public int SelectedProcessId { get; set; }
        public string PantoneNo { get; set; }
        public long ColorSetId { get; set; }

        public virtual WovenSelectedWetProcesses SelectedProcess { get; set; }
    }
}
