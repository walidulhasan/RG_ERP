using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.UserDepartmentAccess.Queries
{
    public class GetDDLUserDepartmentQuery : IRequest<List<SelectListItem>>
    {
        public GetDDLUserDepartmentQuery()
        {
            CompanyID = new List<int>();
            DivisionID = new List<int>();
            IsAll = false;

        }
        public int UserID { get; set; }
        public List<int> CompanyID { get; set; }
        public List<int> DivisionID { get; set; }
        public bool IsAll { get; set; }
        public string Predict { get; set; } = null;
    }

    public class GetDDLUserDepartmentQueryHandler : IRequestHandler<GetDDLUserDepartmentQuery, List<SelectListItem>>
    {
        private readonly IUserDepartmentAccessService _userDepartmentAccessService;

        public GetDDLUserDepartmentQueryHandler(IUserDepartmentAccessService userDepartmentAccessService)
        {
            _userDepartmentAccessService = userDepartmentAccessService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLUserDepartmentQuery request, CancellationToken cancellationToken)
        {
            return await _userDepartmentAccessService.DDLUserDepartment(request.UserID,request.CompanyID,request.DivisionID, request.IsAll,request.Predict, cancellationToken);
        }
    }
}
