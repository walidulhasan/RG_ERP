using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsJob
    {
        public SfsJob()
        {
            SfsJobConfirmation = new HashSet<SfsJobConfirmation>();
            SfsJobDetail = new HashSet<SfsJobDetail>();
            SfsJobResource = new HashSet<SfsJobResource>();
            SfsPickListMaster = new HashSet<SfsPickListMaster>();
        }

        public long JobId { get; set; }
        public long StyleId { get; set; }
        public int Status { get; set; }
        public long SfsPrsid { get; set; }
        public long? StartWcdayId { get; set; }
        public int? StartMinuteId { get; set; }
        public long? EndWcdayId { get; set; }
        public int? EndMinuteId { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual SfsJobStatus StatusNavigation { get; set; }
        public virtual ICollection<SfsJobConfirmation> SfsJobConfirmation { get; set; }
        public virtual ICollection<SfsJobDetail> SfsJobDetail { get; set; }
        public virtual ICollection<SfsJobResource> SfsJobResource { get; set; }
        public virtual ICollection<SfsPickListMaster> SfsPickListMaster { get; set; }
    }
}
