using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.CalenderEventDetail.Queries.RequestResponseModel
{
    public class GetAllCalenderEventDetailsQM
    {
        public int TrainingCategoryID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
