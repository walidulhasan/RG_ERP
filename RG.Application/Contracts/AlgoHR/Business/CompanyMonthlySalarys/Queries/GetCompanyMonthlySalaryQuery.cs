using MediatR;
using RG.Application.Contracts.AlgoHR.Business.CompanyMonthlySalarys.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.CompanyMonthlySalarys.Queries
{
    public class GetCompanyMonthlySalaryQuery:IRequest<List<CompanyMonthlySalaryRM>>
    {
        public int CompanyId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
    public class GetCompanyMonthlySalaryQueryHandler : IRequestHandler<GetCompanyMonthlySalaryQuery, List<CompanyMonthlySalaryRM>>
    {
        private readonly ICompanyMonthlySalaryService _companyMonthlySalaryService;

        public GetCompanyMonthlySalaryQueryHandler(ICompanyMonthlySalaryService companyMonthlySalaryService)
        {
            _companyMonthlySalaryService = companyMonthlySalaryService;
        }
        public async Task<List<CompanyMonthlySalaryRM>> Handle(GetCompanyMonthlySalaryQuery request, CancellationToken cancellationToken)
        {
            return await _companyMonthlySalaryService.GetCompanyMonthlySalary(request.CompanyId,request.Month,request.Year,cancellationToken);
        }
    }
}
