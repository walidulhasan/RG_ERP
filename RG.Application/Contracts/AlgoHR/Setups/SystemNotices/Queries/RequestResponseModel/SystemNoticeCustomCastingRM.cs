using RG.Application.Common.Mappings;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Queries.RequestResponseModel
{
    public class SystemNoticeCustomCastingRM:IMapFrom<SystemNoticeCustomCusting>
    {
        public int CustingID { get; set; }
        public int NoticeID { get; set; }
        public int CompanyID { get; set; }
        public int DivisionID { get; set; }
        public int DepartmentID { get; set; }
        public int SectionID { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap< SystemNoticeCustomCusting, SystemNoticeCustomCastingRM>();
        }
    }
}
