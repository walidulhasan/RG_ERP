using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.AlgoHR.Setup;

namespace RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Commands.DataTransferModel
{
    public class SystemNoticeCustomCustingDTM:IMapFrom<SystemNoticeCustomCusting>
    {
        public int CustingID { get; set; }        
        public int NoticeID { get; set; }
        public int CompanyID { get; set; }
        public int? DivisionID { get; set; }
        public int? DepartmentID { get; set; }
        public int? SectionID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SystemNoticeCustomCustingDTM, SystemNoticeCustomCusting>();
        }
    }
}
