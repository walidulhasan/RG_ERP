using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class KRS_MASTER_DEL
    {
        public KRS_MASTER_DEL()
        {
            KRS_DETAIL_DEL = new HashSet<KRS_DETAIL_DEL>();
            KRS_YARN_DETAILS_DEL = new HashSet<KRS_YARN_DETAILS_DEL>();
            KRS_Colors_DEL = new HashSet<KRS_Colors_DEL>();
            KRS_SIZES_DEL = new HashSet<KRS_SIZES_DEL>();
            KRS_STYLE_INFO_DEL = new HashSet<KRS_STYLE_INFO_DEL>();

        }
        public int ID { get; set; }
        public int KRSID { get; set; }
        public string Code { get; set; }
        public string UserID { get; set; }
        public string CompanyID { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        public DateTime? DeliveryDate { get; set; }

      public ICollection< KRS_DETAIL_DEL> KRS_DETAIL_DEL { get; set; }
        public ICollection<KRS_YARN_DETAILS_DEL> KRS_YARN_DETAILS_DEL { get; set; }
        public ICollection<KRS_Colors_DEL> KRS_Colors_DEL { get; set; }
        public ICollection<KRS_SIZES_DEL> KRS_SIZES_DEL { get; set; }
        public ICollection<KRS_STYLE_INFO_DEL> KRS_STYLE_INFO_DEL { get; set; }
 
    }
}
