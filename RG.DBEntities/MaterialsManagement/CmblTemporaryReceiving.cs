using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblTemporaryReceiving
    {
        public CmblTemporaryReceiving()
        {
            CmblTemporaryReceivingDetail = new HashSet<CmblTemporaryReceivingDetail>();
        }
        [Key]
        public int Trid { get; set; }
        public int Poid { get; set; }
        public int Grid { get; set; }
        public int Trno { get; set; }
        public int InspectionStatus { get; set; }
        public long CompanyId { get; set; }
        public int Deleted { get; set; }
        public DateTime TempRecDate { get; set; }
        public int UserId { get; set; }

        public virtual CmblGateReceiving Gr { get; set; }
        public virtual ICollection<CmblTemporaryReceivingDetail> CmblTemporaryReceivingDetail { get; set; }
    }
}
