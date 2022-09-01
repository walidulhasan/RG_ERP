using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class KRS_Sizes
    {
        [Key]
        public long KRSSID { get; set; }
        [ForeignKey("KRS_DETAIL")]
        public int KRSDID { get; set; }
        public int SizeID { get; set; }
        public decimal Len { get; set; }
        public decimal Wid { get; set; }
        public string Color { get; set; }
        public decimal? Quantity { get; set; }
        public virtual KRS_DETAIL KRS_DETAIL { get; set; }
    }
}
