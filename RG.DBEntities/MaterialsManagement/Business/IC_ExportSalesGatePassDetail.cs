using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class IC_ExportSalesGatePassDetail : DefaultTableProperties
    {
        [Key]
        public int Id { get; set; }
        public string SNO { get; set; }
        public string ItemName { get; set; }
        public int? UnitId { get; set; }
        public string InvoiceNumber { get; set; }
        public string FormENo { get; set; }
        public string ContainerNo { get; set; }
        public string ContainerSize { get; set; }
        public string BuyerName { get; set; }
        public string ClearingAgent { get; set; }
        public string SealNo { get; set; }
        public string ShippingLine { get; set; }
        [ForeignKey("IC_ExportSalesGatePassMaster")]
        public long? ExportSalesGatePassID { get; set; }
        public string Remarks { get; set; }
        public decimal? Quantity { get; set; }
        public long? CartonQty { get; set; }
        public int? BuyerID { get; set; }
        public int? OrderID { get; set; }
        public int? CountryID { get; set; }
        public string PONumber { get; set; }
        public virtual IC_ExportSalesGatePassMaster IC_ExportSalesGatePassMaster { get; set; }
    }
}
