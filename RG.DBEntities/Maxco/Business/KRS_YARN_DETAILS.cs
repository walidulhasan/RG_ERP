using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class KRS_YARN_DETAILS 
    {
        public int ID { get; set; }
        [ForeignKey("KRS_DETAIL")]
        public int KRS_DID { get; set; }
        public int YARN_COUNTID { get; set; }
        public int YARN_COMPOSITIONID { get; set; }
        public int YARN_QUALITYID { get; set; }
        public double UTILIZATION { get; set; }
        public double? CONSUMPTION { get; set; }
        public double? ColorID { get; set; }
        public string Pantone { get; set; }
        public string FabPantone { get; set; }
        public virtual KRS_DETAIL KRS_DETAIL { get; set; }
    }
}

