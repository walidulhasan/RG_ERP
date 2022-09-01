using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.AssetDepartments.Queries
{
    public class GetDivisionWiseDDLDepartmentQuery:IRequest<List<SelectListItem>>
    {
        public int DivisionId { get; set; }
        public string Predict { get; set; }
    }
    public class GetDivisionWiseDDLDepartmentQueryHandler : IRequestHandler<GetDivisionWiseDDLDepartmentQuery, List<SelectListItem>>
    {
        private readonly IAssetDepartmentService _assetDepartmentService;

        public GetDivisionWiseDDLDepartmentQueryHandler(IAssetDepartmentService assetDepartmentService)
        {
            _assetDepartmentService = assetDepartmentService;
        }
        public async Task<List<SelectListItem>> Handle(GetDivisionWiseDDLDepartmentQuery request, CancellationToken cancellationToken)
        {
            return await _assetDepartmentService.GetDivisionWiseDDLDepartment(request.DivisionId,request.Predict,cancellationToken);
        }
    }
}
