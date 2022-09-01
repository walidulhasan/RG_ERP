using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MrpitemAttributeInstance
    {
        public MrpitemAttributeInstance()
        {
            MirallocatedAtHand = new HashSet<MirallocatedAtHand>();
            MiratHand = new HashSet<MiratHand>();
            MirgrossNet = new HashSet<MirgrossNet>();
            MirscheduleReceipt = new HashSet<MirscheduleReceipt>();
            MrpitemAttributeSetValues = new HashSet<MrpitemAttributeSetValues>();
            MrpitemMovingAverage = new HashSet<MrpitemMovingAverage>();
        }
        public int Id { get; set; }
        public long AttributeInstanceId { get; set; }
        public string Adesc { get; set; }

        public virtual ICollection<MirallocatedAtHand> MirallocatedAtHand { get; set; }
        public virtual ICollection<MiratHand> MiratHand { get; set; }
        public virtual ICollection<MirgrossNet> MirgrossNet { get; set; }
        public virtual ICollection<MirscheduleReceipt> MirscheduleReceipt { get; set; }
        public virtual ICollection<MrpitemAttributeSetValues> MrpitemAttributeSetValues { get; set; }
        public virtual ICollection<MrpitemMovingAverage> MrpitemMovingAverage { get; set; }
    }
}
