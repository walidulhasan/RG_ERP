using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Yarn_POMaster
    {
      
        public long Yarn_POID { get; set; }
        public string YarnPONo { get; set; }
        public int YarnBrokerID { get; set; }
        public decimal SupplierID { get; set; }
        public int ModeID { get; set; }
        public int TermID { get; set; }
        public int CartageID { get; set; }
        public int? YarnStoreLocationID { get; set; }
        public int? KnitterID { get; set; }
        public int? ProcurementTypeID { get; set; }
        public int? ProcurementPurposeID { get; set; }
        public int? ColorItalTypeID { get; set; }
        public int? ColorItalImportID { get; set; }
        public int? ColorItalExportID { get; set; }
        public int LifeCycleStatus { get; set; }
        public bool IsLatestVersion { get; set; }
        public string Remarks { get; set; }
        public string UserName { get; set; }
        public DateTime? PODate { get; set; }
        public int? UserID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserID { get; set; }
        public string ModifiedUserName { get; set; }
        public int? ProgramTypeID { get; set; }
        public int? OrderID { get; set; }
        public string OrderNo { get; set; }
        public int? DaysOfPayment { get; set; }
        public bool? IsImport { get; set; }
        public string LcNumber { get; set; }
        public long? CompanyID { get; set; }
        public int? BusinessID { get; set; }
        public int? AdvancePercentage { get; set; }
        public string PINO { get; set; }
        public int? YPC_ID { get; set; }
    }
}
