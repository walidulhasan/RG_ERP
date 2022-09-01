using RG.Application.Common.Mappings;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Commands.DataTransferModel
{
    public class CalenderEventMastersDTM : IMapFrom<CalenderEventMaster>
    {
        public int ID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public List<CalenderEventDetail> CalenderEventDetail { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<CalenderEventMastersDTM, CalenderEventMaster>().ReverseMap();
        }
    }

    public class CalenderEventDetail : IMapFrom<CalenderEventDetails>
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int TrainingCategoryID { get; set; }
        public DateTime EventDateTime { get; set; }
        public string EventTitle { get; set; }
        public string EventVenue { get; set; }
        public string Stakeholder { get; set; }
        public string EventDuration { get; set; }
        public string EventTrainer { get; set; }
        public string TrainingType { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<CalenderEventDetail, CalenderEventDetails>();
        }
    }
}
