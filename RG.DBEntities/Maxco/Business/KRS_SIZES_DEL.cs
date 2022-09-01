using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco
{
    public partial class KRS_SIZES_DEL
    {
        public long KRSSID { get; set; }
        public int KRSDID { get; set; }
        public int SizeID { get; set; }
        public decimal Len { get; set; }
        public decimal Wid { get; set; }
        public string Color { get; set; }
        public decimal Quantity { get; set; }
        [ForeignKey("KRS_MASTER_DEL")]
        public int MainID { get; set; }

        public KRS_MASTER_DEL KRS_MASTER_DEL { get; set; }
    }
}
