using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries.RequestResponseModel
{
   public class UserApprovalPowerRM
    {
        public int ApproverDesignationID { get; set; }
        public int? ApproverEmployeeID { get; set; }
        public string ApproverGroup { get; set; }
    }
}
