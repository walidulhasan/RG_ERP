using RG.Application.Contracts.AlgoHR.Business.DivisionOtherCosts.Queries.RequestResponseModel;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface IDivisionOtherCostRepository:IGenericRepository<DivisionOtherCost>
    {
        Task<List<DivisionOtherCostRM>> GetMonthWiseDivisionOtherCost(int salaryAnalysisDivisionID, int month, int year, CancellationToken cancellationToken);
    }
}
