using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public partial class Dyed_StockTransactions
    {
        [Key]
        public long StockTransactionID { get; set; }
        public int? ProgramTypeID { get; set; }
        public int DocumentTypeID { get; set; }
        public long? DocumentNo { get; set; }
        public DateTime DocumentDate { get; set; }
        public long DyeingLotID { get; set; }
        public string DyeingLotNo { get; set; }
        public long AttributeInstanceID { get; set; }
        public double Quantity { get; set; }
        public double? ReceivedWidth { get; set; }
        public int? ReceivedGsm { get; set; }
        public double? SKURate { get; set; }
        public int? SKUUnit { get; set; }
        public int? UserSelectedUnit { get; set; }
        public long OrderID { get; set; }
        public long ModelID { get; set; }
        public long DyeingContractID { get; set; }
        public long GreigeRollID { get; set; }
        public string DyedRollNo { get; set; }
        public int StoreLocationID { get; set; }
        public int Status { get; set; }
        public string Comments { get; set; }
        public string RotaryCode { get; set; }
        public int? CuttingDetailID { get; set; }
        public long? fid { get; set; }
        public long? IsShortFall { get; set; }
        public string rollnonew { get; set; }
    }
}
