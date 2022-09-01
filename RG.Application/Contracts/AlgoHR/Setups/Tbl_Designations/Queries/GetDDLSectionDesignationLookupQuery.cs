using MediatR;
using RG.Application.Common.Utilities;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Designations.Queries
{
   public class GetDDLSectionDesignationLookupQuery :IRequest<List<IdNamePairRM>>
    {
        public List<int> SectionID { get; set; }
        public string Predict { get; set; }
    }
    public class GetDDLSectionDesignationLookupQueryHandler : IRequestHandler<GetDDLSectionDesignationLookupQuery, List<IdNamePairRM>>
    {
        private readonly ITbl_DesignationService _tbl_DesignationService;

        public GetDDLSectionDesignationLookupQueryHandler(ITbl_DesignationService tbl_DesignationService)
        {
            _tbl_DesignationService = tbl_DesignationService;
        }
        public async Task<List<IdNamePairRM>> Handle(GetDDLSectionDesignationLookupQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_DesignationService.DDLSectionDesignationLookup(request.SectionID, request.Predict, cancellationToken);
        }
    }
}
