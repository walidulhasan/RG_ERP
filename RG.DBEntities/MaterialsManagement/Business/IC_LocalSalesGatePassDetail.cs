using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class IC_LocalSalesGatePassDetail : DefaultTableProperties
    {
        [Key]
        public long ID { get; set; }
        public string RefNo { get; set; }
        public int? OrderID { get; set; }
        public string OrderName { get; set; }
        public string OrderNo { get; set; }
        public string ProcessCodeID { get; set; }
        public string ColorFinishCode { get; set; }
        public decimal Quantity { get; set; }
        public int UnitID { get; set; }
        public decimal? Rate { get; set; }
        public decimal? SalesTaxPercent { get; set; }
        public string SalesTaxInvoiceNo { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? NetWeight { get; set; }
        public string Remarks { get; set; }
        [ForeignKey("IC_LocalSalesGatePassMaster")]
        public long LocalSalesGatePassID { get; set; }
        public int? ProcessID { get; set; }
        public decimal? InputWeight { get; set; }
        public string ItemType { get; set; }
        public string Roll { get; set; }
        public long? IssuanceDetailID { get; set; }
        public int? PaymentMode { get; set; }
        public decimal? GreigeWidth { get; set; }
        public decimal? FinishedWidth { get; set; }
        public virtual IC_LocalSalesGatePassMaster IC_LocalSalesGatePassMaster { get; set; }
    }
}
