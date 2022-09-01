using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco
{
    public partial class KRS_Colors_DEL
    {
        public long KRSCID { get; set; }
        public int KRSDID { get; set; }
        public decimal Quantity { get; set; }
        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        public int? ColorID { get; set; }
        [ForeignKey("KRS_MASTER_DEL")]
        public int? MainID { get; set; }
        public KRS_MASTER_DEL KRS_MASTER_DEL { get; set; }
    }
}
