using AutoMapper;
using RG.Application.Contracts.AlgoHR.Setups.CompanyKPIParticularss.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using RG.Application.Interfaces.Services.Embro.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class CompanyKPIParticularsService : ICompanyKPIParticularsService
    {
        private readonly ICompanyKPIParticularsRepository _companyKPIParticularsRepository;
        private readonly IMapper _mapper;
        private readonly ITbl_Currency_SetupService _tbl_Currency_SetupService;

        public CompanyKPIParticularsService(ICompanyKPIParticularsRepository companyKPIParticularsRepository, IMapper mapper, ITbl_Currency_SetupService tbl_Currency_SetupService)
        {
            _companyKPIParticularsRepository = companyKPIParticularsRepository;
            _mapper = mapper;
            _tbl_Currency_SetupService = tbl_Currency_SetupService;
        }
        public async Task<List<CompanyKPIParticularsRM>> GetAllCompanyKPIParticulars(int kpiMonth, int kpiYear, CancellationToken cancellationToken)
        {
            var data = await _companyKPIParticularsRepository.GetAllCompanyKPIParticulars(kpiMonth, kpiYear, cancellationToken);
            return data;

        }

        public async Task<List<CompanyKPIReportRM>> GetAllCompanyKPIParticularsReport(int kpiMonth, int kpiYear, int forLastYears, CancellationToken cancellationToken)
        {
            var conversion = await _tbl_Currency_SetupService.GetCurrencyRate(2);
            var conversionRate = conversion.CurrencyRate.RateInBDT.Value;
            var data= await _companyKPIParticularsRepository.GetAllCompanyKPIParticularsReport(kpiMonth, kpiYear, forLastYears, cancellationToken);
            data.ForEach(x => { x.ConversionRate = conversionRate; });
            return data;
        }
    }
}
