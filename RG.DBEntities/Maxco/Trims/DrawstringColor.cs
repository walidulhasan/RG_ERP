using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
    public class DrawstringColor
    {
        public int ID { get; set; }
        [ForeignKey("DrawstringSpecification")]
        public int ObjectID { get; set; }
        public string TrimColor { get; set; }
        [ForeignKey("FabricSpecificationColor")]
        public long ColorSetID { get; set; }
        public int MatchID { get; set; }
        public bool IsTippingColor { get; set; }

        public virtual FabricSpecificationColor ColorSet { get; set; }
        public virtual DrawstringSpecification Object { get; set; }
    }
}
