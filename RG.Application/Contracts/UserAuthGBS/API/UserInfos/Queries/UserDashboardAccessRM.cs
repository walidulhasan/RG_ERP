using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.UserAuthGBS.API.UserInfos.Queries
{
    public class UserDashboardAccessRM
    {
        public int UserDashboardAccessID { get; set; }
        public int AccessTypeID { get; set; }
        public string AccessTypeName { get; set; }
        public List<SelectListItem> DDLAccessItems { get; set; }

        public bool IsAuthTestServer { get; set; }
        public bool IsMaxcoTestServer { get; set; }
        public bool IsMaterialsManagementTestServer { get; set; }
        public bool IsFiniteSchedulerTestServer { get; set; }
        public bool IsEmbroTestServer { get; set; }
        public bool IsAOPTestServer { get; set; }
        public bool IsEMSTestServer { get; set; }
        public bool IsAlgoHRTestServer { get; set; }

    }
    
}
