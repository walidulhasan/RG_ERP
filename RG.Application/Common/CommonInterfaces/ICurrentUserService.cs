using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Common.CommonInterfaces
{
    public interface ICurrentUserService
    {
        bool IsAuthenticated { get; }
        int UserID { get; }
        string UserName { get; }
        bool IsSuperAdminRole { get; }
        string UserEmail { get; }
        string UserType { get; }
        int RoleID { get; }
        string RoleName { get; }
        int CompanyID { get; }
        int BusinessID { get; }
        int AlgoUserID { get; }
        string CompanyName { get; }
        int EmployeeID { get; }
        string EmployeeCode { get; }
        bool HasClaimAccess(string policyType);

    }
}
