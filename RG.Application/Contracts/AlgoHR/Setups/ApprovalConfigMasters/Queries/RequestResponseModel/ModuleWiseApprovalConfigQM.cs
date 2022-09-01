using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries.RequestResponseModel
{
    public class ModuleWiseApprovalConfigQM
    {
        public string ModuleName { get; set; }
        public int? ConfigCompanyID { get; set; }
        public int? ConfigOfficeDivisionID { get; set; }
        public int? ConfigDepartmentID { get; set; }
        public int? ConfigSectionID { get; set; }
        public int? ConfigJobTitleID { get; set; }
    }
}
