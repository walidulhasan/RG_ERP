using RG.Application.Contracts.AlgoHR.Business.DivisionSalaryCosts.Queries.RequestResponseModel;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface IDivisionSalaryCostRepository:IGenericRepository<DivisionSalaryCost>
    {
        Task<List<DivisionSalaryCostRM>> GetMonthWiseDivisionSalaryCost(int salaryAnalysisDivisionID, int month, int year, CancellationToken cancellationToken);

    }
}
