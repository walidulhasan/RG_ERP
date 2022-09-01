using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnSpecificationColor
    {
        //public FabricYarnSpecificationColor()
        //{
        //    FabricYarnSpecification = new HashSet<FabricYarnSpecification>();
        //}
        public int ID { get; set; }
        [ForeignKey("FabricYarnSpecification")]
        public long YarnSpecificationID { get; set; }
        [ForeignKey("FabricSpecificationColor")]
        public long? ColorsetID { get; set; }
        public string PantoneNo { get; set; }
        public int? VendorColorID { get; set; }
        public bool? IsSelected { get; set; }
        public int? ColorIndex { get; set; }
        public int? PalleteTypeID { get; set; }
        public string ColorName { get; set; }
        public int? Utilization { get; set; }

        public virtual FabricSpecificationColor FabricSpecificationColor { get; set; }
        public virtual FabricYarnSpecification FabricYarnSpecification { get; set; }
    }
}
