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
  public  class GetDDLUserDivisionQuery :IRequest<List<SelectListItem>>
    {
        public GetDDLUserDivisionQuery()
        {
            CompanyID = new List<int>();
           
            IsAll = false;

        }
        public int UserID { get; set; }
        public List<int> CompanyID { get; set; }
        public string Predict { get; set; } = null;
        public bool IsAll { get; set; }
    }

    public class GetDDLUserDivisionQueryHandler : IRequestHandler<GetDDLUserDivisionQuery, List<SelectListItem>>
    {
        private readonly IUserDepartmentAccessService _userDepartmentAccessService;

        public GetDDLUserDivisionQueryHandler(IUserDepartmentAccessService userDepartmentAccessService)
        {
            _userDepartmentAccessService = userDepartmentAccessService;

        }
        public async Task<List<SelectListItem>> Handle(GetDDLUserDivisionQuery request, CancellationToken cancellationToken)
        {
            return await _userDepartmentAccessService.DDLUserDivision(request.UserID, request.CompanyID, request.IsAll,request.Predict, cancellationToken);
        }
    }
}
