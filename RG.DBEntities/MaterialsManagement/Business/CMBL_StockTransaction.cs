using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class CMBL_StockTransaction
    {
        [Key]
        public long StockTransactionID { get; set; }
        public int DocumentTypeID { get; set; }
        public int DocumentNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public long ItemID { get; set; }
        public decimal Quantity { get; set; }
        public int UserSelectedUnit { get; set; }
        public decimal Rate_WRTbaseUnit { get; set; }
        public int StoreLocationID { get; set; }
        public int Status { get; set; }
        public int Deleted { get; set; }
        public long CompanyID { get; set; }
        public long? IRRID { get; set; }
        public string Comments { get; set; }
        public long? ModelID { get; set; }
        public long? Misc { get; set; }
        public long? YarnKNContractID { get; set; }
        public long? OrderID { get; set; }
        public long? StyleID { get; set; }
        public long? aop_ReqDID { get; set; }

        public virtual CMBL_Item CMBL_Item { get; set; }
    }
}
