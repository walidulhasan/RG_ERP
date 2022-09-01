using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class KRS_Colors
    {
       [Key]
        public long KRSCID { get; set; }
        [ForeignKey("KRS_DETAIL")]
        public int KRSDID { get; set; }
        public decimal Quantity { get; set; }
        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        public int? ColorID { get; set; }
        public decimal? QuantityWOW{ get; set; }
        public int? PID { get; set; }
        public int? CID { get; set; }
        public virtual KRS_DETAIL KRS_DETAIL { get; set; }
    }
}
