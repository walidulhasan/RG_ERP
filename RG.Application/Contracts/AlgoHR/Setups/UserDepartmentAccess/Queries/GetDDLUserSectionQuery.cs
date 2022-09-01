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
    public class GetDDLUserSectionQuery:IRequest<List<SelectListItem>>
    {
        public GetDDLUserSectionQuery()
        {
            CompanyID = new List<int>();
            DivisionID = new List<int>();
            DepartmentID = new List<int>();
            IsAll = false;

        }
        public int UserID { get; set; }
        public List<int> CompanyID { get; set; }
        public List<int> DivisionID { get; set; }
        public List<int> DepartmentID { get; set; }
        public bool IsAll { get; set; }
        public string Predict { get; set; } = null;
    }

    public class GetDDLUserSectionQueryHandler : IRequestHandler<GetDDLUserSectionQuery, List<SelectListItem>>
    {
        private readonly IUserDepartmentAccessService _userDepartmentAccessService;

        public GetDDLUserSectionQueryHandler(IUserDepartmentAccessService userDepartmentAccessService)
        {
            _userDepartmentAccessService = userDepartmentAccessService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLUserSectionQuery request, CancellationToken cancellationToken)
        {
            return await _userDepartmentAccessService.DDLUserSection(request.UserID,request.CompanyID,request.DivisionID,request.DepartmentID,request.IsAll,request.Predict,cancellationToken);
        }
    }
}
