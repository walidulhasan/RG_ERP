using RG.Application.Common.Mappings;

namespace RG.Application.Contracts.AlgoHR.Setups.UserDepartmentAccess.Commands.DataTransferModel
{
    public class UserDepartmentAccessCreateDTM:IMapFrom<DBEntities.AlgoHR.Setup.UserDepartmentAccess>
    {
        public int CA_UserID { get; set; }
        public int Embro_CompanyID { get; set; }
        public int DivisionID { get; set; }
        public int DepartmentID { get; set; }
        public int SectionID { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<UserDepartmentAccessCreateDTM, DBEntities.AlgoHR.Setup.UserDepartmentAccess>().ReverseMap();
        }
    }
}
