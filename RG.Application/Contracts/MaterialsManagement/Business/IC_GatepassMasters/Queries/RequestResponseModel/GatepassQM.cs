using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel
{
    public class GatepassQM
    {
        public int CategoryID { get; set; }
        public int StatusID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsApproved { get; set; }
        public int ApprovedById { get; set; }
        public bool? IsAccountsApprovalRequired { get; set; }
        public bool? isAccountApprove { get; set; }

        public bool? IsMarkedOut { get; set; }
        public int? MarkedOutById { get; set; }
        public string Status { get; set; } = "All";
        /// <summary>
        /// Old User ID
        /// </summary>
        public int Algo_UserId { get; set; }
        /// <summary>
        /// Authentication User ID
        /// New Application
        /// </summary>
        public int CA_UserId { get; set; }
        public string GatePassNo { get; set; }

        public int? IsExpired { get; set; }
    }
}
