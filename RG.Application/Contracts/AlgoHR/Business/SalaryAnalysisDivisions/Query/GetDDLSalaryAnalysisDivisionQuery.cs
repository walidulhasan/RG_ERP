using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.SalaryAnalysisDivisions.Query
{
    public class GetDDLSalaryAnalysisDivisionQuery:IRequest<List<SelectListItem>>
    {

    }
    public class GetDDLSalaryAnalysisDivisionQueryHandler : IRequestHandler<GetDDLSalaryAnalysisDivisionQuery, List<SelectListItem>>    
    {
        private readonly ISalaryAnalysisDivisionService _salaryAnalysisDivisionService;

        public GetDDLSalaryAnalysisDivisionQueryHandler(ISalaryAnalysisDivisionService salaryAnalysisDivisionService)
        {
            _salaryAnalysisDivisionService = salaryAnalysisDivisionService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLSalaryAnalysisDivisionQuery request, CancellationToken cancellationToken)
        {
            return await _salaryAnalysisDivisionService.DDLSalaryAnalysisDivision(cancellationToken);
        }
    }
}
