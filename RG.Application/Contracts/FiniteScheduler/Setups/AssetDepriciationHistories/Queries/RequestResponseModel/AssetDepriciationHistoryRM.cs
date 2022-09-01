using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Queries.RequestResponseModel
{
    public class AssetDepriciationHistoryRM
    {
        public int ID { get; set; }
        public string AssetName { get; set; }
        public DateTime DateFrom { get; set; }
        public string DateFromMsg { get { return DateFrom.ToString("dd-MMM-yyyy"); } }
        public string DateTo { get; set; }
        public decimal Rate { get; set; }
        public string DepricationType { get; set; }
        public decimal ValueAfterDeprication { get; set; }
        public decimal DepricationValue { get; set; }
    }
}
