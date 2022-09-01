using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Vw_OutSideTask.Query.RequestResponseModel
{
    public class OutSideTaskSearchQM
    {
        public List<int> Companies { get; set; }
        public List<int> Divisions { get; set; }
        public List<int> Departmetns { get; set; }
        public List<int> Sections { get; set; }
        public List<long> Employees { get; set; }
        public int? ApplicationStatus { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
