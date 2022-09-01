using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco
{
    public partial class KRS_YARN_DETAILS_DEL
    {
        public int ID { get; set; }
        public int KRS_DID { get; set; }
        public int YARN_COUNTID { get; set; }
        public int YARN_COMPOSITIONID { get; set; }
        public int YARN_QUALITYID { get; set; }
        public int UTILIZATION { get; set; }
        public DateTime? DATE { get; set; } = DateTime.Now;
        public double? CONSUMPTION { get; set; }
        public int? ColorID { get; set; }
        public string Pantone { get; set; }
        [ForeignKey("KRS_MASTER_DEL")]
        public int? MainID { get; set; }
        
        public KRS_MASTER_DEL KRS_MASTER_DEL { get; set; }
    }
}
