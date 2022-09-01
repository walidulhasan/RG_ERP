using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
  public partial  class ModelFinishFabricCost
    {
        public int ID { get; set; }
        public int FabricID { get; set; }
        public double FinishFabricConsumption { get; set; }
        public int FabricColorID { get; set; }
        public long StyleID { get; set; }
        public int CollectionID { get; set; }
        public double FinishFabricCost { get; set; }
        public double? PricePerKg { get; set; }
        public int? FabricCategoryID { get; set; }
        public string PantoneNo { get; set; }
        public int? FabricTypeID { get; set; }
        public int? FabricQualityID { get; set; }
        public int? GSM { get; set; }
        public int? CompositionID { get; set; }
        public int? ConstructionID { get; set; }
        public int? DyeingID { get; set; }
        public int? FinishedWidth { get; set; }
        [ForeignKey("ModelCosting")]
        public int? VersionID { get; set; }
        public bool? IsPrinting { get; set; }
        public bool? IsDyeing { get; set; }
        public bool? IsBleaching { get; set; }
        public double? PrintingPrice { get; set; }
        public double? DyeingPrice { get; set; }
        public double? BleachingPrice { get; set; }
        public double? PrintingCost { get; set; }
        public double? DyeingCost { get; set; }
        public double? BleachingCost { get; set; }
        public int? DenimWeightID { get; set; }
        public int? DenimBuyerID { get; set; }
        public string DenimBuyerCode { get; set; }
        public string Unit { get; set; }
        public double? MarkerEfficiency { get; set; }
        public string PrintingCode { get; set; }
        public string RotaryImagePath { get; set; }
        public int? ProcurementUnitID { get; set; }
        public double? DyeingWastagePerFrac { get; set; }
        public double? DyeingRate { get; set; }
        public double? AllOverPrintPrice { get; set; }

        public virtual ModelCosting ModelCosting { get; set; }
    }
}
