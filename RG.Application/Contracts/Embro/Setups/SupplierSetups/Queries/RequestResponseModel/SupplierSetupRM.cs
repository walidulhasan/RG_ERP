using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.Embro.Setup;

namespace RG.Application.Contracts.Embro.Setups.SupplierSetups.Queries.RequestResponseModel
{
    public class SupplierSetupRM : IMapFrom<SupplierSetup>
    {
        public decimal ID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string SalesTaxRegNumber { get; set; }
        public string NTNNumber { get; set; }
        public string Comments { get; set; }
        public string SupplierType { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SupplierSetupRM, SupplierSetup>().ReverseMap();
        }
    }
}
