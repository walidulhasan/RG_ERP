using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.UserAuthGBS.API.UserInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.UserAuthGBS.API.UserInfos.Queries
{
    public class GetDDLCompanyQuery : IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLCompanyQueryHandler : IRequestHandler<GetDDLCompanyQuery, List<SelectListItem>>
    {
        private readonly IUserAccessInfoService _userAccessInfoService;

        public GetDDLCompanyQueryHandler(IUserAccessInfoService userAccessInfoService)
        {
            _userAccessInfoService = userAccessInfoService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLCompanyQuery request, CancellationToken cancellationToken)
        {
            return await _userAccessInfoService.GetDDLCompany();
        }
    }
}
