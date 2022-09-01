using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Commands.DataTransferModel
{
    public class UpdateReplaceApproverDTM
    {
        public string ModuleName { get; set; }
        public int FromEmployeeID { get; set; }
        public int ToEmployeeID { get; set; }
        public int ToCompanyID { get; set; }
        public int ToDivisionID { get; set; }
        public int ToDepartmentID { get; set; }
        public int ToSectionID { get; set; }
        public int ToDesignationID { get; set; }
        public int LastModifiedBy { get; set; }
    }
}
