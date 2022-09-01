using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SpreaderInstance
    {
        public SpreaderInstance()
        {
            ResourceGroup = new HashSet<ResourceGroup>();
            SpreaderLoad = new HashSet<SpreaderLoad>();
        }

        public int SpreaderMachineTypeId { get; set; }
        public string SpreaderInstanceName { get; set; }
        public int FamId { get; set; }
        public int FamparentId { get; set; }
        public int StateId { get; set; }

        public virtual SpreaderMachineType Famparent { get; set; }
        public virtual ICollection<ResourceGroup> ResourceGroup { get; set; }
        public virtual ICollection<SpreaderLoad> SpreaderLoad { get; set; }
    }
}
