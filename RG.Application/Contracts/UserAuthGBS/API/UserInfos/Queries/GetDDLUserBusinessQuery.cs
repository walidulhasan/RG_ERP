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
   public class GetDDLUserBusinessQuery :IRequest<List<SelectListItem>>
    {
        public int CompanyID { get; set; }
        public int UserID { get; set; }
    }

    public class GetDDLUserBusinessQueryHandler : IRequestHandler<GetDDLUserBusinessQuery, List<SelectListItem>>
    {
        private readonly IUserAccessInfoService _userAccessInfoService;

        public GetDDLUserBusinessQueryHandler(IUserAccessInfoService userAccessInfoService)
        {
            _userAccessInfoService = userAccessInfoService;

        }

        public async Task<List<SelectListItem>> Handle(GetDDLUserBusinessQuery request, CancellationToken cancellationToken)
        {
            return await _userAccessInfoService.GetDDLUserBusiness(request.UserID,request.CompanyID);
        }
    }
}
