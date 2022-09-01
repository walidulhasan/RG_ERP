using RG.Application.Common.Mappings;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.CalenderEventFeedbacks.Commands.DataTransferModel
{
    public class CalenderEventFeedbackDTM : IMapFrom<CalenderEventFeedback>
    {
        public int EventDetailsID { get; set; }
        public string Comments { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<CalenderEventFeedbackDTM, CalenderEventFeedback>().ReverseMap();
        }
    }
}
