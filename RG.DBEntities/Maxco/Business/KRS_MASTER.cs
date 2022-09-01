using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class KRS_MASTER
    {
        public KRS_MASTER()
        {
            KRS_DETAIL = new HashSet<KRS_DETAIL>();
        }
        public int ID { get; set; }
        public string Code { get; set; }
        public string UserID { get; set; }
        public decimal? CompanyID { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? GrossStatus { get; set; }
        public string Ref { get; set; }
        public int? BYR { get; set; }
        public virtual ICollection<KRS_DETAIL> KRS_DETAIL { get; set; }
    }
}
