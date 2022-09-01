using MediatR;
using RG.Application.Common.Utilities;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Sections.Queries
{
    public class GetDDLSectionLookupQuery : IRequest<List<IdNamePairRM>>
    {
        public List<int> DepartmentID { get; set; }
        public string Predict { get; set; } = null;
    }
    public class GetDDLSectionLookupQueryHandler : IRequestHandler<GetDDLSectionLookupQuery, List<IdNamePairRM>>
    {
        private readonly ITbl_SectionService _tbl_SectionService;

        public GetDDLSectionLookupQueryHandler(ITbl_SectionService tbl_SectionService)
        {
            _tbl_SectionService = tbl_SectionService;
        }
        public async Task<List<IdNamePairRM>> Handle(GetDDLSectionLookupQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_SectionService.DDLSectionLookup(request.DepartmentID, request.Predict, cancellationToken);
        }
    }
}
