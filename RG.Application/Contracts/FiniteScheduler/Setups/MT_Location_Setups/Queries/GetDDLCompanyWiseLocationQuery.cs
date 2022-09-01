using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_Location_Setups.Queries
{
    public class GetDDLCompanyWiseLocationQuery:IRequest<List<SelectListItem>>
    {
        public int CompanyID { get; set; }
    }
    public class GetDDLCompanyWiseLocationQueryHandler : IRequestHandler<GetDDLCompanyWiseLocationQuery, List<SelectListItem>>
    {
        private readonly IMT_Location_SetupService mt_Location_SetupService;

        public GetDDLCompanyWiseLocationQueryHandler(IMT_Location_SetupService _mt_Location_SetupService)
        {
            mt_Location_SetupService = _mt_Location_SetupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLCompanyWiseLocationQuery request, CancellationToken cancellationToken)
        {
            return await mt_Location_SetupService.DDLCompanyWiseLocation(request.CompanyID, cancellationToken);
        }
    }
}
