using MediatR;
using RG.Application.Contracts.AlgoHR.Business.SalaryAnalysisDivisions.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.SalaryAnalysisDivisions.Query
{
    public class GetAnalysisDivisionWiseSalaryQuery:IRequest<List<AnalysisDivisionWiseSalaryRM>>
    {
        public string AnalysisDivision { get; set; }
        public string DepartmentGroup { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
    public class GetAnalysisDivisionWiseSalaryQueryHandler : IRequestHandler<GetAnalysisDivisionWiseSalaryQuery, List<AnalysisDivisionWiseSalaryRM>>
    {
        private readonly ISalaryAnalysisDivisionService _salaryAnalysisDivisionService;

        public GetAnalysisDivisionWiseSalaryQueryHandler(ISalaryAnalysisDivisionService salaryAnalysisDivisionService)
        {
            _salaryAnalysisDivisionService = salaryAnalysisDivisionService;
        }
        public async Task<List<AnalysisDivisionWiseSalaryRM>> Handle(GetAnalysisDivisionWiseSalaryQuery request, CancellationToken cancellationToken)
        {
            return await _salaryAnalysisDivisionService.GetAnalysisDivisionWiseSalary(request.AnalysisDivision,request.DepartmentGroup, request.Year, request.Month, cancellationToken);
        }
    }
}
