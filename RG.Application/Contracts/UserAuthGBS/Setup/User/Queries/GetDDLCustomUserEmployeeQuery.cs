using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.UserAuthGBS.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.UserAuthGBS.Setup.User.Queries
{
    public class GetDDLCustomUserEmployeeQuery : IRequest<List<DropDownItem>>
    {
        public string Predict { get; set; }
    }
    public class GetDDLCustomUserEmployeeQueryHandler : IRequestHandler<GetDDLCustomUserEmployeeQuery, List<DropDownItem>>
    {
        private readonly IUserEmployeeService _userEmployeeService;

        public GetDDLCustomUserEmployeeQueryHandler(IUserEmployeeService userEmployeeService)
        {
            _userEmployeeService = userEmployeeService;
        }
        public async Task<List<DropDownItem>> Handle(GetDDLCustomUserEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _userEmployeeService.GetDDLCustomUserEmployee(request.Predict);
        }
    }
}