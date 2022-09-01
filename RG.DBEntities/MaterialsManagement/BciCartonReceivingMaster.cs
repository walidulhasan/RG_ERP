using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciCartonReceivingMaster
    {
        public BciCartonReceivingMaster()
        {
            BciCartonReceivingDetail = new HashSet<BciCartonReceivingDetail>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ReceivingNumber { get; set; }

        public virtual ICollection<BciCartonReceivingDetail> BciCartonReceivingDetail { get; set; }
    }
}
