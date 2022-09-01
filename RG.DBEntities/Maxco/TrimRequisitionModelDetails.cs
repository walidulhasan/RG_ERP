using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TrimRequisitionModelDetails
    {
        public TrimRequisitionModelDetails()
        {
            TrimPodetail = new HashSet<TrimPodetail>();
        }
        public int Id { get; set; }
        public int Trmdid { get; set; }
        public int Trdid { get; set; }
        public string ModelNo { get; set; }
        public double Quantity { get; set; }
        public int UnitId { get; set; }
        public int RequiredDayId { get; set; }

        public virtual TrimRequisitionDetail Trd { get; set; }
        public virtual ICollection<TrimPodetail> TrimPodetail { get; set; }
    }
}
