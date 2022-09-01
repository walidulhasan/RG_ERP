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
   public class GetDDLBasicCoaQuery :IRequest<List<SelectListItem>>
    {
        public int?ParentID { get; set; }
        public int LevelID { get; set; }
        public string Predict { get; set; } = null;
    }
    public class GetDDLBasicCoaQueryHandler : IRequestHandler<GetDDLBasicCoaQuery, List<SelectListItem>>
    {
        private readonly IBasicCOAService _basicCOAService;

        public GetDDLBasicCoaQueryHandler(IBasicCOAService basicCOAService)
        {
            _basicCOAService = basicCOAService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLBasicCoaQuery request, CancellationToken cancellationToken)
        {
            return await _basicCOAService.DDLChartOfAccounts(request.ParentID,request.LevelID,request.Predict, cancellationToken);
        }
    }
}
