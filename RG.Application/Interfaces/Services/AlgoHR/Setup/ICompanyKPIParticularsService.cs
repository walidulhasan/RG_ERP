using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.AlgoHR.Setups.CompanyKPIParticularss.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Setup
{
    public interface ICompanyKPIParticularsService
    {
        Task<List<CompanyKPIParticularsRM>> GetAllCompanyKPIParticulars(int kpiMonth,int kpiYear,CancellationToken cancellationToken);
        Task<List<CompanyKPIReportRM>> GetAllCompanyKPIParticularsReport(int kpiMonth, int kpiYear,int forLastYears, CancellationToken cancellationToken);
    }
}
