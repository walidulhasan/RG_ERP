using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries
{
    public class DDLCompanyWiseChartOfAccountsQuery : IRequest<List<SelectListItem>>
    {
        public int ParentID { get; set; }
        public int LevelID { get; set; }
        public string Predict { get; set; } = null;
    }
    public class DDLCompanyWiseChartOfAccountsQueryHandler : IRequestHandler<DDLCompanyWiseChartOfAccountsQuery, List<SelectListItem>>
    {
        private readonly IBasicCOAService _basicCOAService;

        public DDLCompanyWiseChartOfAccountsQueryHandler(IBasicCOAService basicCOAService)
        {
            _basicCOAService = basicCOAService;
        }
        public async Task<List<SelectListItem>> Handle(DDLCompanyWiseChartOfAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _basicCOAService.DDLCompanyWiseChartOfAccounts(request.ParentID, request.LevelID, request.Predict, cancellationToken);
        }
    }
}
