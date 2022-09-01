using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public partial class Yarn_KnittingContractTippingSpecification
    {
        [Key]
        public long TippingID { get; set; }
        public long? KnittingContractID { get; set; }
        public int? TippingVeltNo { get; set; }
        public double? Width { get; set; }
        public double? DistanceFromOuterEdge { get; set; }
        public int? IsTipping { get; set; }
        public long? YarnID { get; set; }
        public long? YarnAttributeInstanceID { get; set; }

        public virtual Yarn_KnittingContractMaster Yarn_KnittingContractMaster { get; set; }
    }
}
