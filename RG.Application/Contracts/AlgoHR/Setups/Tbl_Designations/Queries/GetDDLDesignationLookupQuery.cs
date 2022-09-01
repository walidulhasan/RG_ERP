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
   public class GetDDLDesignationLookupQuery :IRequest<List<IdNamePairRM>>
    {
        public List<int> CompanyID { get; set; }
        public List<int> DivisionID { get; set; }
        public List<int> DepartmentID { get; set; }
        public List<int> SectionID { get; set; }
        public string Predict { get; set; }

    }

    public class GetDDLDesignationLookupQueryHandler : IRequestHandler<GetDDLDesignationLookupQuery, List<IdNamePairRM>>
    {
        private readonly ITbl_DesignationService _tbl_DesignationService;

        public GetDDLDesignationLookupQueryHandler(ITbl_DesignationService tbl_DesignationService)
        {
            _tbl_DesignationService = tbl_DesignationService;
        }
        public async Task<List<IdNamePairRM>> Handle(GetDDLDesignationLookupQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_DesignationService.DDLDesignationLookup(request.CompanyID, request.DivisionID, request.DepartmentID, request.SectionID, request.Predict, cancellationToken);
        }
    }
}
