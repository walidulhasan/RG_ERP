using RG.DBEntities.Maxco.Trims;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricSpecificationColor
    {
        public FabricSpecificationColor()
        {
            BeadColor = new HashSet<BeadColor>();
           // BiFacedFabricColors = new HashSet<BiFacedFabricColors>();
            BuckleColor = new HashSet<BuckleColor>();
            ButtonColor = new HashSet<ButtonColor>();
          //  DenimWetProcessesMain = new HashSet<DenimWetProcessesMain>();
            DrawstringColor = new HashSet<DrawstringColor>();
            ElasticColor = new HashSet<ElasticColor>();
           // EmbroColor = new HashSet<EmbroColor>();
          //  EmbroPrintThreadColor = new HashSet<EmbroPrintThreadColor>();
          //  EyeletColor = new HashSet<EyeletColor>();
          //  FabricTieSpotDyeColors = new HashSet<FabricTieSpotDyeColors>();
            FabricYarnSpecificationColor = new HashSet<FabricYarnSpecificationColor>();
          //  FurColor = new HashSet<FurColor>();
          //  HangTagColors = new HashSet<HangTagColors>();
         //   InverseShellColor = new HashSet<FabricSpecificationColor>();
           LabelColors = new HashSet<LabelColors>();
            LaceColor = new HashSet<LaceColor>();
            //  NetMeshColor = new HashSet<NetMeshColor>();
            //  RivetColor = new HashSet<RivetColor>();
            ThreadColor = new HashSet<ThreadColor>();
            //   ThreadColor2 = new HashSet<ThreadColor2>();
            //TwillTapeColor = new HashSet<TwillTapeColor>();
            //VelcroColor = new HashSet<VelcroColor>();
            //ZipColor = new HashSet<ZipColor>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }
        [ForeignKey("FabricSpecification")]
        public long FabricSpecificationID { get; set; }
        public string PantoneNo { get; set; }
        public int? DyeingProcessID { get; set; }
        
        public int? FabricYarnVendorColorID { get; set; }
        public string ColorName { get; set; }
        public int? MatchingSourceID { get; set; }
        public int? PalletTypeID { get; set; }
        public long? ShellColorID { get; set; }
        public int? ColorIndex { get; set; }
        public int? CompanyId { get; set; }

        public virtual FabricSpecification FabricSpecification { get; set; }
       // public virtual FabricSpecificationColor ShellColor { get; set; }
        public virtual ICollection<BeadColor> BeadColor { get; set; }
      //  public virtual ICollection<BiFacedFabricColors> BiFacedFabricColors { get; set; }
        public virtual ICollection<BuckleColor> BuckleColor { get; set; }
        public virtual ICollection<ButtonColor> ButtonColor { get; set; }
       // public virtual ICollection<DenimWetProcessesMain> DenimWetProcessesMain { get; set; }
        public virtual ICollection<DrawstringColor> DrawstringColor { get; set; }
        public virtual ICollection<ElasticColor> ElasticColor { get; set; }
        //public virtual ICollection<EmbroColor> EmbroColor { get; set; }
        //public virtual ICollection<EmbroPrintThreadColor> EmbroPrintThreadColor { get; set; }
        //public virtual ICollection<EyeletColor> EyeletColor { get; set; }
        //public virtual ICollection<FabricTieSpotDyeColors> FabricTieSpotDyeColors { get; set; }
        public virtual ICollection<FabricYarnSpecificationColor> FabricYarnSpecificationColor { get; set; }
        //public virtual ICollection<FurColor> FurColor { get; set; }
        //public virtual ICollection<HangTagColors> HangTagColors { get; set; }
        //public virtual ICollection<FabricSpecificationColor> InverseShellColor { get; set; }
        public virtual ICollection<LabelColors> LabelColors { get; set; }
        public virtual ICollection<LaceColor> LaceColor { get; set; }
        //public virtual ICollection<NetMeshColor> NetMeshColor { get; set; }
        //public virtual ICollection<RivetColor> RivetColor { get; set; }
        public virtual ICollection<ThreadColor> ThreadColor { get; set; }
        //public virtual ICollection<ThreadColor2> ThreadColor2 { get; set; }
        //public virtual ICollection<TwillTapeColor> TwillTapeColor { get; set; }
        //public virtual ICollection<VelcroColor> VelcroColor { get; set; }
        //public virtual ICollection<ZipColor> ZipColor { get; set; }
    }
}
