using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class CalenderEventDetails : DefaultTableProperties
    {
        public int ID { get; set; }
        [ForeignKey("CalenderEventMaster")]
        public int EventID { get; set; }
        public int TrainingCategoryID { get; set; }
        public DateTime EventDateTime { get; set; }
        public string EventTitle { get; set; }
        public string EventVenue { get; set; }
        public string Stakeholder { get; set; }
        public string EventDuration { get; set; }
        public string EventTrainer { get; set; }
        public string TrainingType { get; set; }
        public virtual CalenderEventMaster CalenderEventMaster { get; set; }
    }
}
