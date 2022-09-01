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
  public  class GetDDLUserCompanyQuery :IRequest<List<SelectListItem>>
    {
       public int UserID { get; set; }
       public bool IsAll { get; set; } = false;
    }

    public class GetDDLUserCompanyQueryHandler : IRequestHandler<GetDDLUserCompanyQuery, List<SelectListItem>>
    {
        private readonly IUserDepartmentAccessService _userDepartmentAccessService;

        public GetDDLUserCompanyQueryHandler(IUserDepartmentAccessService userDepartmentAccessService)
        {
            _userDepartmentAccessService = userDepartmentAccessService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLUserCompanyQuery request, CancellationToken cancellationToken)
        {
            return await _userDepartmentAccessService.DDLUserCompany(request.UserID,request.IsAll);
        }
    }
}
