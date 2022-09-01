using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class KRS_STYLE_INFO
    {
        public int ID { get; set; }
        [ForeignKey("KRS_DETAIL")]
        public int KRS_DID { get; set; }
        public int STYLEID { get; set; }
        public double CONSUMPTION { get; set; }
        public double? CONSUMPTIONWOW { get; set; }
        public virtual KRS_DETAIL KRS_DETAIL { get; set; }
    }
}
