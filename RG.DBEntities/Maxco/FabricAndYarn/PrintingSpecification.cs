using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class PrintingSpecification
    {
        public PrintingSpecification()
        {
            PrintingLayers = new HashSet<PrintingLayers>();
            PrintPlacementInstruction = new HashSet<PrintPlacementInstruction>();
            PrintSizes = new HashSet<PrintSizes>();
          //  PrintingColor = new HashSet<PrintingColor>();
            //PrintingPlacementInstruction = new HashSet<PrintingPlacementInstruction>();
        }

        public int ID { get; set; }
        public int? ImageID { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public int? VariantID { get; set; }
        public int StyleID { get; set; }
        public string Comments { get; set; }
        public int VersionNo { get; set; }
        public int Status { get; set; }
        public int SelectedElementID { get; set; }
        public int? FabricSpecificationID { get; set; }
        public int? MeasurementScaleID { get; set; }
        public int? FlockMaterialID { get; set; }
        public double? Thickness { get; set; }
        public bool? IsThreading { get; set; }
        public int? InsertionID { get; set; }
        public int? DescriptionType { get; set; }
        public bool? IsValid { get; set; }

        //public virtual FlockMaterialSetup FlockMaterial { get; set; }
        //public virtual StyleElementMeasurementScale MeasurementScale { get; set; }
        //public virtual PrintingVariantSetup Variant { get; set; }
        public virtual ICollection<PrintingLayers> PrintingLayers { get; set; }
        public virtual ICollection<PrintPlacementInstruction> PrintPlacementInstruction { get; set; }
        public virtual ICollection<PrintSizes> PrintSizes { get; set; }
       // public virtual ICollection<PrintingColor> PrintingColor { get; set; }
        //public virtual ICollection<PrintingPlacementInstruction> PrintingPlacementInstruction { get; set; }
    }
}
