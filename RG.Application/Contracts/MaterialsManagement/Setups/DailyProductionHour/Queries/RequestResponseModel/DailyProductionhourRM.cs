using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Queries.RequestResponseModel
{
    public class DailyProductionhourRM
    {
        public int ID { get; set; }
        public string ProductionType { get; set; }
        public decimal TimeFrom { get; set; }
        public decimal TimeTo { get; set; }
        public decimal LapTiming { get; set; }
        public string Description { get; set; }
    }
}
