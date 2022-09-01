using MediatR;
using RG.Application.Contracts.AlgoHR.Business.CompanyMonthlySalarys.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.CompanyMonthlySalarys.Queries
{
    public class GetCompanyDivisionMonthlySalaryQuery : IRequest<List<CompanyMonthlySalaryRM>>
    {
        public int CompanyId { get; set; }
        public int DivisionId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
    public class GetCompanyDivisionMonthlySalaryQueryHandler : IRequestHandler<GetCompanyDivisionMonthlySalaryQuery, List<CompanyMonthlySalaryRM>>
    {
        private readonly ICompanyMonthlySalaryService _companyMonthlySalaryService;

        public GetCompanyDivisionMonthlySalaryQueryHandler(ICompanyMonthlySalaryService companyMonthlySalaryService)
        {
            _companyMonthlySalaryService = companyMonthlySalaryService;
        }
        public async Task<List<CompanyMonthlySalaryRM>> Handle(GetCompanyDivisionMonthlySalaryQuery request, CancellationToken cancellationToken)
        {
            return await _companyMonthlySalaryService.GetCompanyDivisionMonthlySalary(request.CompanyId, request.DivisionId, request.Month, request.Year,cancellationToken);
        }
    }
}
