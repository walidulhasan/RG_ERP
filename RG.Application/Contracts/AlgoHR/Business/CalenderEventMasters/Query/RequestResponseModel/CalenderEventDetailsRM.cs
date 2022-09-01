using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Query.RequestResponseModel
{
    public class CalenderEventDetailsRM
    {
        public int ID { get; set; }
        public int MasterID { get; set; }
        public int EventID { get; set; }
        public int TrainingCategoryID { get; set; }
        public string EventDateTime { get; set; }
        public string EventTitle { get; set; }
        public string EventVenue { get; set; }
        public string Stakeholder { get; set; }
        public string EventDuration { get; set; }
        public string EventTrainer { get; set; }
        public string TrainingType { get; set; }

        public virtual string Time { get;set; }
    }
}
