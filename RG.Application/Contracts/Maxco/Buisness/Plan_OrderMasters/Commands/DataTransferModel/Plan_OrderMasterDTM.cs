using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Commands.DataTransferModel
{
    public class Plan_OrderMasterDTM
    {
        public int PlanID { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderReceiveDate { get; set; }
    }
}
