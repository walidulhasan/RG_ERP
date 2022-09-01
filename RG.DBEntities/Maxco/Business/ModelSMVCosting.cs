using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class ModelSMVCosting
    {
        public int ID { get; set; }
        public int RateTypeID { get; set; }
        public long StyleID { get; set; }
        public int CollectionID { get; set; }
        [ForeignKey("ModelCosting")]
        public int VersionID { get; set; }
        public double SMVRate { get; set; }
        public double CostPerMinute { get; set; }
        public virtual ModelCosting ModelCosting { get; set; }
    }
}
