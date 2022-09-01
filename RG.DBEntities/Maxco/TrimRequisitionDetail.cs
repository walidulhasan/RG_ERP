using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TrimRequisitionDetail
    {
        public TrimRequisitionDetail()
        {
            TrimRequisitionModelDetails = new HashSet<TrimRequisitionModelDetails>();
        }
        public int Id { get; set; }
        public int Trdid { get; set; }
        public int Trmid { get; set; }
        public int MrpitemCode { get; set; }
        public long AttributeInstanceId { get; set; }

        public virtual TrimRequisitionMaster Trm { get; set; }
        public virtual ICollection<TrimRequisitionModelDetails> TrimRequisitionModelDetails { get; set; }
    }
}
