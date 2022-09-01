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
   public class DDLChartOfAccountsCategoryQuery : IRequest<List<SelectListItem>>
    {
        public int CompanyID { get; set; }
        public int LevelID { get; set; }
        public string Category { get; set; } = null;
        public string Predict { get; set; } = null;
    }
    public class DDLChartOfAccountsCategoryQueryHandler : IRequestHandler<DDLChartOfAccountsCategoryQuery, List<SelectListItem>>
    {
        private readonly IBasicCOAService _basicCOAService;

        public DDLChartOfAccountsCategoryQueryHandler(IBasicCOAService basicCOAService)
        {
            _basicCOAService = basicCOAService;
        }
        public async Task<List<SelectListItem>> Handle(DDLChartOfAccountsCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _basicCOAService.DDLChartOfAccounts(request.CompanyID,request.LevelID,request.Category, request.Predict, cancellationToken);
        }
    }
}
