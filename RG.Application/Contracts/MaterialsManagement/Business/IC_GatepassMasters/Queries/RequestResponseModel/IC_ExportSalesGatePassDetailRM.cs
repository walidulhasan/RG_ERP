using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Business;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel
{
    public class IC_ExportSalesGatePassDetailRM : IMapFrom<IC_ExportSalesGatePassDetail>
    {
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
        public long? ExportSalesGatePassID { get; set; }
        public string Remarks { get; set; }
        public decimal? Quantity { get; set; }
        public long? CartonQty { get; set; }
        public int? BuyerID { get; set; }
        public int? OrderID { get; set; }
        public int? CountryID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_ExportSalesGatePassDetailRM, IC_ExportSalesGatePassDetail>().ReverseMap();
        }
    }
}