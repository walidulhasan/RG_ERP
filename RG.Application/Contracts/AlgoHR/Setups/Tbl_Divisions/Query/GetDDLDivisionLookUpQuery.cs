using MediatR;
using RG.Application.Common.Utilities;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Divisions.Query
{
   public class GetDDLDivisionLookUpQuery :IRequest<List<IdNamePairRM>>
    {
       public List<int> EmbroCompanyID { get; set; }
       public List<int> ExceptDivision { get; set; }
       public string Predict { get; set; } = null;
    }

    public class GetDDLDivisionLookUpQueryHandler : IRequestHandler<GetDDLDivisionLookUpQuery, List<IdNamePairRM>>
    {
        private readonly ITbl_DivisionService _tbl_DivisionService;

        public GetDDLDivisionLookUpQueryHandler(ITbl_DivisionService tbl_DivisionService)
        {
            _tbl_DivisionService = tbl_DivisionService;
        }
        public async Task<List<IdNamePairRM>> Handle(GetDDLDivisionLookUpQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_DivisionService.DDLDivisionLookUp(request.EmbroCompanyID,request.ExceptDivision,request.Predict,cancellationToken);
        }
    }
}
