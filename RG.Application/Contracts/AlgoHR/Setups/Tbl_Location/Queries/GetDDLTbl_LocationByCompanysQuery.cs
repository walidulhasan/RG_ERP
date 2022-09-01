using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Location.Queries
{
   public class GetDDLTbl_LocationByCompanysQuery :IRequest<List<SelectListItem>>
    {
        public GetDDLTbl_LocationByCompanysQuery()
        {
            CompanyList = new List<int>();
        }
        public List<int> CompanyList { get; set; }
        public string Predict { get; set; }
    }
    public class GetDDLTbl_LocationByCompanysQueryHandler : IRequestHandler<GetDDLTbl_LocationByCompanysQuery, List<SelectListItem>>
    {
        private readonly ITbl_LocationService _tbl_LocationService;

        public GetDDLTbl_LocationByCompanysQueryHandler(ITbl_LocationService tbl_LocationService)
        {
            _tbl_LocationService = tbl_LocationService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLTbl_LocationByCompanysQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_LocationService.DDLLocation(request.CompanyList, request.Predict, cancellationToken);
        }
    }
}
