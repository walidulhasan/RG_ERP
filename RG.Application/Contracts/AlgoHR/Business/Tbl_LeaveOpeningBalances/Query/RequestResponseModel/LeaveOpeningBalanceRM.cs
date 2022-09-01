using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Business;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_LeaveOpeningBalances.Query.RequestResponseModel
{
    public class LeaveOpeningBalanceRM : IMapFrom<Tbl_LeaveOpeningBalance>
    {
        public int ID { get; set; }
        public string EmpCD { get; set; }
        public int Year { get; set; }
        public int LeaveID { get; set; }
        public int OpeningBalance { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LeaveOpeningBalanceRM, Tbl_LeaveOpeningBalance>().ReverseMap();
        }
    }
}
