using RG.Application.Common.Mappings;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Queries.RequestResponseModel
{
    public class SystemNoticeRM:IMapFrom<SystemNotice>
    {
        public SystemNoticeRM()
        {
           CustomCasting = new List<SystemNoticeCustomCastingRM>();
        }
        public int NoticeID { get; set; }
        public string NoticeTitle { get; set; }
        public string NoticeDescription { get; set; }
        public DateTime ValidDateFrom { get; set; }
        public DateTime ValidDateTo { get; set; }
        public string ValidDateFromMsg { get; set; }        
        public string ValidDateToMsg { get; set; }
        public bool ShowDetail { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap< SystemNotice, SystemNoticeRM>();
        }

        public List<SystemNoticeCustomCastingRM> CustomCasting { get; set; }

    }
    
}
