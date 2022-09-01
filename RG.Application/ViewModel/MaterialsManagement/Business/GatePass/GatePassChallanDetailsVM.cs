using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Business.GatePass
{
    public class GatePassChallanDetailsVM
    {
        public int ID { get; set; }
        public string RefNo { get; set; }
        public string ItemName { get; set; }
        public string InvoiceNumber { get; set; }
        public string OrderNo { get; set; }
        public string ProcessCodeID { get; set; }
        public string ContainerNo { get; set; }
        public string ContainerSize { get; set; }
        public string BuyerName { get; set; }
        public string ClearingAgent { get; set; }
        public string SealNo { get; set; }
        public string ShippingLine { get; set; }
        public string Remarks { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityOrGrossWeight { get; set; }
        public long CartonQty { get; set; }
        public string ExpectedReturnDate { get; set; }
        public int? UnitID { get; set; }
        public string UnitName { get; set; }
        public int DecimalPoint { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal? RecieveQuantity { get; set; }
        public decimal? WastageQuantity { get; set; }
        public string ReturnableItemCategory { get; set; }
        public int RequisitionID { get; set; }
        public string PaymentTerm { get; set; }
        public string CountryName { get; set; }
        public decimal? GreigeWidth { get; set; }
        public decimal? FinishedWidth { get; set; }
        public decimal? Rate { get; set; }
        public string Roll { get; set; }

        public int IsCalculationWithGray { get; set; }
    }
}
