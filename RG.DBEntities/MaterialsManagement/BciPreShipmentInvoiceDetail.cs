using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciPreShipmentInvoiceDetail
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }

        public virtual BciPreShipmentInvoice Master { get; set; }
    }
}
