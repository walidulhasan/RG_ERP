using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class QRM_OrderSheetFabrics
    {
        public QRM_OrderSheetFabrics()
        {
            //LcFpManufacturefabricPi = new HashSet<LcFpManufacturefabricPi>();
        }

        public int ID { get; set; }
        public int? MrpitemCode { get; set; }
        public long AttributeInstanceID { get; set; }
        public int? FabricTypeID { get; set; }
        public int? FabricQualityID { get; set; }
        public double? DyeingRate { get; set; }
        public double? DyeingWastagePerFrac { get; set; }
        public string FabricComposition { get; set; }
        public int? DyeingID { get; set; }
        public int? GSM { get; set; }
        public decimal? FinishedWidth { get; set; }
        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        [ForeignKey("QRM_OrderSheetVersions")]
        public int VersionID { get; set; }
        public double? RequiredQty { get; set; }
        public double? UnitConsumption { get; set; }
        public double? SKUCost { get; set; }
        public int? SizeID { get; set; }
        public string SizeDescription { get; set; }
        public int? UnitID { get; set; }
        public string Unit { get; set; }
        public int? ProcurementUnitID { get; set; }
        public double? WastagePercent { get; set; }

        public virtual QRM_OrderSheetVersions QRM_OrderSheetVersions { get; set; }
        //public virtual ICollection<LcFpManufacturefabricPi> LcFpManufacturefabricPi { get; set; }
    }
}
