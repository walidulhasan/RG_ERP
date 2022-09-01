using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class ApprovalConfigDetail : DefaultTableProperties
    {
        public int ConfigDetailID { get; set; }
        [ForeignKey("ApprovalConfigMaster")]
        public int ConfigMasterID { get; set; }
        public int? ApprovalLevel { get; set; }
        public int? ApproverCompanyID { get; set; }
        public int? ApproverOfficeID { get; set; }
        public int? ApproverOfficeDivisionID { get; set; }
        public int? ApproverDepartmentID { get; set; }
        public int? ApproverSectionID { get; set; }
        public int ApproverJobTitleID { get; set; }
        public int? ApproverEmployeeID { get; set; }
        public bool? IsApproverInSelfOffice { get; set; }

        public virtual ApprovalConfigMaster ApprovalConfigMaster { get; set; }
    }
}
