using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.CalenderEventDetail.Queries.RequestResponseModel
{
    public class GetAllCalenderEventDetailsRM
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int TrainingCategoryID { get; set; }
        public string TrainingCategory { get; set; }
        public DateTime EventDateTime { get; set; }
        public string EventTitle { get; set; }
        public string EventVenue { get; set; }
        public string EventDuration { get; set; }
        public string EventTrainer { get; set; }
        public string TrainingType { get; set; }
    }
}
