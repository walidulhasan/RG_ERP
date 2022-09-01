using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco
{
    public partial class KRS_STYLE_INFO_DEL
    {
        public int ID { get; set; }
        public int KRS_DID { get; set; }
        public long STYLEID { get; set; }
        public double CONSUMPTION { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        [ForeignKey("KRS_MASTER_DEL")]
        public int? MainID { get; set; }
        public KRS_MASTER_DEL KRS_MASTER_DEL { get; set; }
    }
}
