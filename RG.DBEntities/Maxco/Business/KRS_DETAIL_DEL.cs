using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco
{
    public partial class KRS_DETAIL_DEL
    {
        public int ID { get; set; }
        public int KRS_MID { get; set; }
        public int FABID { get; set; }
        public int TYPEID { get; set; }
        public int QUALITYID { get; set; }
        public string FAB_COMPOSITION { get; set; }
        public int GSM { get; set; }
        public int GAUGE { get; set; }
        public double FINISHED_WIDTH { get; set; }
        public int ISSPANDEX { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        public int? DYEINGID { get; set; }

        [ForeignKey("KRS_MASTER_DEL")]
        public int? DetailID { get; set; }
        [Key]
        public int MainID { get; set; }

        public KRS_MASTER_DEL KRS_MASTER_DEL { get; set; }
    }
}
