using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class ApprovalConfigMaster : DefaultTableProperties
    {
        public ApprovalConfigMaster()
        {
            ApprovalConfigDetail = new HashSet<ApprovalConfigDetail>();
        }
        public int ConfigMasterID { get; set; }
        public string ModuleName { get; set; }
        public int? ConfigCompanyID { get; set; }
        public int? ConfigOfficeID { get; set; }
        public int? ConfigOfficeDivisionID { get; set; }
        public int? ConfigDepartmentID { get; set; }
        public int? ConfigSectionID { get; set; }
        public int? ConfigJobTitleID { get; set; }

        public virtual ICollection<ApprovalConfigDetail> ApprovalConfigDetail { get; set; }

    }
}
