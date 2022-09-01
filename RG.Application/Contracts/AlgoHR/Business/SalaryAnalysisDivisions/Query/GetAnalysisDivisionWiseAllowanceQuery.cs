using MediatR;
using RG.Application.Contracts.AlgoHR.Business.SalaryAnalysisDivisions.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.SalaryAnalysisDivisions.Query
{
    public class GetAnalysisDivisionWiseAllowanceQuery : IRequest<List<AnalysisDivisionWiseAllowanceRM>>
    {
        public string AnalysisDivision { get; set; }
        public string DepartmentGroup { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
    public class GetAnalysisDivisionWiseAllowanceQueryHandler : IRequestHandler<GetAnalysisDivisionWiseAllowanceQuery, List<AnalysisDivisionWiseAllowanceRM>>
    {
        private readonly ISalaryAnalysisDivisionService _salaryAnalysisDivisionService;

        public GetAnalysisDivisionWiseAllowanceQueryHandler(ISalaryAnalysisDivisionService salaryAnalysisDivisionService)
        {
            _salaryAnalysisDivisionService = salaryAnalysisDivisionService;
        }
        public async Task<List<AnalysisDivisionWiseAllowanceRM>> Handle(GetAnalysisDivisionWiseAllowanceQuery request, CancellationToken cancellationToken)
        {
            return await _salaryAnalysisDivisionService.GetAnalysisDivisionWiseAllowance(request.AnalysisDivision,request.DepartmentGroup, request.Year, request.Month, cancellationToken);
        }
    }
}
