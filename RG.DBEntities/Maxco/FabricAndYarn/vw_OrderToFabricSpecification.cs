using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public class vw_OrderToFabricSpecification
    {
        [Key]
        public long? RowSl { get; set; }
        public long OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderNo { get; set; }
        public int? CollectionInfoID { get; set; }
        public int? ShellFabricCategoryID { get; set; }
        //public int CompanyID { get; set; }
        public long StyleID { get; set; }
        public string StyleName { get; set; }
        public int FabricTrimSelectedID { get; set; }
        public int? FabricTrimID { get; set; }
        public int SelectedElementID { get; set; }
        public long FabricSpecificationID { get; set; }
        public int? FabricTypeID { get; set; }
        public int? FabricQualityID { get; set; }
        public int? GSM { get; set; }
        public int? MachineTypeID { get; set; }
        public int? FabricGuageID { get; set; }
        public int? FabricDyeingTypeID { get; set; }
        public string FabricComposition { get; set; }
        public int? FabricCategoryID { get; set; }
        public bool IsSpandex { get; set; }
        public decimal FinishedWidth { get; set; }
        public int? ProcurementUnitID { get; set; }
        public int BuyerID { get; set; }
    }
}
