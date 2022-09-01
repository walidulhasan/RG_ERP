using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.AssetDivisions.Queries
{
    public class EmbroCompanyWiseDDLDivisionQuery:IRequest<List<SelectListItem>>
    {
        public int EmbroCompanyID { get; set; }
        public string Predict { get; set; }
    }
    public class EmbroCompanyWiseDDLDivisionQueryHandler : IRequestHandler<EmbroCompanyWiseDDLDivisionQuery, List<SelectListItem>>
    {
        private readonly IAssetDivisionService _assetDivisionService;

        public EmbroCompanyWiseDDLDivisionQueryHandler(IAssetDivisionService assetDivisionService)
        {
            _assetDivisionService = assetDivisionService;
        }
        public async Task<List<SelectListItem>> Handle(EmbroCompanyWiseDDLDivisionQuery request, CancellationToken cancellationToken)
        {
            return await _assetDivisionService.EmbroCompanyWiseDDLDivision(request.EmbroCompanyID,request.Predict,cancellationToken);
        }
    }
}
