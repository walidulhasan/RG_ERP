using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel
{
    public class GatePassAccountIssueQM
    {
        public byte CategoryID { get; set; }
        public string Category { get; set; }
        public string ApprovalType { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public List<int> AccessablePaymentMode { get; set; }
    }
}
