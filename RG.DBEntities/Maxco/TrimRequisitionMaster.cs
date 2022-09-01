using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TrimRequisitionMaster
    {
        public TrimRequisitionMaster()
        {
            TrimRequisitionDetail = new HashSet<TrimRequisitionDetail>();
        }
        public int Id { get; set; }
        public int Trmid { get; set; }
        public string OrderNo { get; set; }
        public string RequestFrom { get; set; }
        public string PreparedBy { get; set; }
        public int Status { get; set; }
        public DateTime? RequisitionDate { get; set; }

        public virtual ICollection<TrimRequisitionDetail> TrimRequisitionDetail { get; set; }
    }
}
