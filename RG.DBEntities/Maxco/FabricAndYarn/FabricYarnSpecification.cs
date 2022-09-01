using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnSpecification
    {
        public FabricYarnSpecification()
        {
            FabricYarnSpecificationColor = new HashSet<FabricYarnSpecificationColor>();
            //FabricFeederStripeSpecification = new HashSet<FabricFeederStripeSpecification>();
            //FabricJacquardSpecificationBaseYarn = new HashSet<FabricJacquardSpecification>();
            //FabricJacquardSpecificationDesignYarn = new HashSet<FabricJacquardSpecification>();
            //FabricYarnTwistingSpecification = new HashSet<FabricYarnTwistingSpecification>();
            //FabricYarnVeltSpecification = new HashSet<FabricYarnVeltSpecification>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }
        [ForeignKey("FabricSpecification")]
        public long FabricSpecificationID { get; set; }
        [ForeignKey("FabricYarnCount_Setup")]
        public long YarnCountID { get; set; }
        [ForeignKey("FabricYarnComposition_Setup")]
        public int YarnCompositionID { get; set; }
        [ForeignKey("FabricYarnQuality_Setup")]
        public int YarnQualityID { get; set; }
        
        [ForeignKey("FabricYarnDyeing_Setup")]
        public int? YarnDyeingID { get; set; }
        public string Color { get; set; }
        [ForeignKey("FabricYarnDesignType_Setup")]
        public int? YarnDesignID { get; set; }  
        [ForeignKey("FabricYarnDyeingMethod_Setup")]
        public int? YarnDyeingMethodID { get; set; }
        [ForeignKey("FabricYarnVendorColorSetup")]
        public int? FabricYarnVendorColorID { get; set; }
        public double? Utilization { get; set; }
        public bool? IsDyed { get; set; }
        public int? YarnIndex { get; set; }
        public int? YarnPly { get; set; }
        public bool? IsBaseStripe { get; set; }
        public virtual FabricSpecification FabricSpecification { get; set; }
        public virtual FabricYarnVendorColor_Setup FabricYarnVendorColor { get; set; }
        public virtual FabricYarnComposition_Setup YarnComposition { get; set; }
       public virtual FabricYarnCount_Setup FabricYarnCount_Setup { get; set; }
       public virtual FabricYarnDesignType_Setup FabricYarnDesignType_Setup { get; set; }
        public virtual FabricYarnDyeing_Setup YarnDyeing { get; set; }
        public virtual FabricYarnDyeingMethod_Setup FabricYarnDyeingMethod_Setup { get; set; }
        public virtual FabricYarnQuality_Setup FabricYarnQuality_Setup { get; set; }
        public virtual ICollection<FabricYarnSpecificationColor> FabricYarnSpecificationColor { get; set; }
        //    public virtual ICollection<FabricFeederStripeSpecification> FabricFeederStripeSpecification { get; set; }
        //   public virtual ICollection<FabricJacquardSpecification> FabricJacquardSpecificationBaseYarn { get; set; }
        //   public virtual ICollection<FabricJacquardSpecification> FabricJacquardSpecificationDesignYarn { get; set; }
        //  public virtual ICollection<FabricYarnTwistingSpecification> FabricYarnTwistingSpecification { get; set; }
        //   public virtual ICollection<FabricYarnVeltSpecification> FabricYarnVeltSpecification { get; set; }
    }
}
