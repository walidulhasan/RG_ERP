using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.AOP.Business;

namespace RG.Application.Contracts.AOP.Business.Tbl_Issuance_Detailss.Queries.RequestResponseModel
{
    public class Tbl_Issuance_DetailsRM : IMapFrom<Tbl_Issuance_Details>
    {
        public long ID { get; set; }
        public long? Transation_ID { get; set; }
        public long? fab_id { get; set; }
        public decimal? fabric_qty { get; set; }
        public long? roll_qty { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tbl_Issuance_DetailsRM, Tbl_Issuance_Details>().ReverseMap();
        }
    }
}
