using RG.Application.Contracts.AlgoHR.Setups.CompanyKPIParticularss.Queries.RequestResponseModel;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Setup
{
    public interface ICompanyKPIParticularsRepository:IGenericRepository<CompanyKPIParticulars>
    {
        Task<List<CompanyKPIParticularsRM>> GetAllCompanyKPIParticulars(int kpiMonth, int kpiYear, CancellationToken cancellationToken);
        Task<List<CompanyKPIReportRM>> GetAllCompanyKPIParticularsReport(int kpiMonth, int kpiYear, int forLastYears, CancellationToken cancellationToken);
    }
}
