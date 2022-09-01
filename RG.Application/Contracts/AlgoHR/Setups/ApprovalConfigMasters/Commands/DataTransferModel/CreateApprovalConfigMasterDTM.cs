using System.Collections.Generic;

namespace RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Commands.DataTransferModel
{
    public class CreateApprovalConfigMasterDTM
    {
        public int ConfigMasterID { get; set; }
        public string ModuleName { get; set; }
        public int? ConfigCompanyID { get; set; }
        public int? ConfigOfficeDivisionID { get; set; }
        public int? ConfigDepartmentID { get; set; }
        public int? ConfigSectionID { get; set; }
        public int? ConfigJobTitleID { get; set; }
        public List<CreateApprovalConfigDetailDTM> ApprovalConfigDetail { get; set; }
    }
}
