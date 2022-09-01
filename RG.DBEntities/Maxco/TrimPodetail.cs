using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TrimPodetail
    {
        public TrimPodetail()
        {
            TrimPodeliveries = new HashSet<TrimPodeliveries>();
        }
        public int Id { get; set; }
        public int Tpodid { get; set; }
        public int Tpomid { get; set; }
        public int Trmdid { get; set; }
        public double Rate { get; set; }
        public double Gst { get; set; }

        public virtual TrimPomaster Tpom { get; set; }
        public virtual TrimRequisitionModelDetails Trmd { get; set; }
        public virtual ICollection<TrimPodeliveries> TrimPodeliveries { get; set; }
    }
}
