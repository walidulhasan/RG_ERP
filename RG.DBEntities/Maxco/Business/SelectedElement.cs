using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class SelectedElement
    {
        public SelectedElement()
        {
          //  EmbroSpecification = new HashSet<EmbroSpecification>();
            FabricTrimSelected = new HashSet<FabricTrimSelected>();
          //  GarmentWashing = new HashSet<GarmentWashing>();
           // PlacementPointSequence = new HashSet<PlacementPointSequence>();
            SelectedGarmentSizeRange = new HashSet<SelectedGarmentSizeRange>();
            SelectedTrim = new HashSet<SelectedTrim>();
          //  SizeChartVersions = new HashSet<SizeChartVersions>();
        }
        public int ID { get; set; }
     
        public long StyleID { get; set; }
       [ForeignKey("OrderStyleElement_Setup")]
        public int OrderStyleElementID { get; set; }
        public int Status { get; set; }
       
        public bool? IsOrder { get; set; }
        public int? Flag { get; set; }
         public Style Style { get; set; }
         public virtual OrderStyleElement_Setup OrderStyleElement_Setup { get; set; }
      //  public virtual ICollection<EmbroSpecification> EmbroSpecification { get; set; }
        public virtual ICollection<FabricTrimSelected> FabricTrimSelected { get; set; }
     //   public virtual ICollection<GarmentWashing> GarmentWashing { get; set; }
      //  public virtual ICollection<PlacementPointSequence> PlacementPointSequence { get; set; }
        public virtual ICollection<SelectedGarmentSizeRange> SelectedGarmentSizeRange { get; set; }
        public virtual ICollection<SelectedTrim> SelectedTrim { get; set; }
      //  public virtual ICollection<SizeChartVersions> SizeChartVersions { get; set; }
    }
}
