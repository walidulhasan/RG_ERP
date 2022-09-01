using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.UserAuthGBS.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.UserAuthGBS.Setup.User.Queries
{
    public class GetDDLUserEmployeeQuery:IRequest<List<SelectListItem>>
    {
        public string Predict { get; set; }
    }
    public class GetDDLUserEmployeeQueryHandler : IRequestHandler<GetDDLUserEmployeeQuery, List<SelectListItem>>
    {
        private readonly IUserEmployeeService _userEmployeeService;

        public GetDDLUserEmployeeQueryHandler(IUserEmployeeService userEmployeeService)
        {
            _userEmployeeService = userEmployeeService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLUserEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _userEmployeeService.GetDDLUserEmployee(request.Predict);
        }
    }
}
