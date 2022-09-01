using MediatR;
using RG.Application.Interfaces.Services.UserAuthGBS.API.UserInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.UserAuthGBS.API.UserInfos.Queries
{
   public class GetUserMenuQuery :IRequest<string>
    {
    }
    public class GetUserMenuQueryHandler : IRequestHandler<GetUserMenuQuery, string>
    {
        private readonly IUserAccessInfoService _userAccessInfoService;

        public GetUserMenuQueryHandler(IUserAccessInfoService userAccessInfoService)
        {
            _userAccessInfoService = userAccessInfoService;
        }
        public async Task<string> Handle(GetUserMenuQuery request, CancellationToken cancellationToken)
        {
            return await _userAccessInfoService.GetUserMenu();
        }
    }
}
