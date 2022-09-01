using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Queries.RequestRespondeModel
{
    public class ProductionEfficiencyRM
    {
        public int ID { get; set; }
        public DateTime ProductionDate { get; set; }
        public string ProductionDateStr { get { return ProductionDate.ToString("dd-MMM-yyyy"); } }
        public decimal? StandardEfficiencyPercent { get; set; }
        public decimal? OverAllEfficiencyPercent { get; set; }
    }
}
