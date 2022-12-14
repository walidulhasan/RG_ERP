using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel
{
    public class IC_LocalSalesGatePassDetailRM : IMapFrom<IC_LocalSalesGatePassDetail>
    {
        public long ID { get; set; }
        public string RefNo { get; set; }
        public int? OrderID { get; set; }
        public string OrderName { get; set; }
        public string OrderNo { get; set; }
        public string ProcessCodeID { get; set; }
        public string ColorFinishCode { get; set; }
        public double Quantity { get; set; }
        public int UnitID { get; set; }
        public double? Rate { get; set; }
        public double? SalesTaxPercent { get; set; }
        public string SalesTaxInvoiceNo { get; set; }
        public double? GrossWeight { get; set; }
        public double? NetWeight { get; set; }
        public string Remarks { get; set; }
        public long LocalSalesGatePassID { get; set; }
        public int? ProcessId { get; set; }
        public double? InputWeight { get; set; }
        public string ItemType { get; set; }
        public string Roll { get; set; }
        public long? IssuanceDetailID { get; set; }
        public int? PaymentMode { get; set; }
        public decimal? GreigeWidth { get; set; }
        public decimal? FinishedWidth { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_LocalSalesGatePassDetailRM, IC_LocalSalesGatePassDetail>().ReverseMap();
        }
    }
}
