using RG.Application.Common.Utilities;
using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Setup
{
    public interface ITbl_CompanyRepository : IGenericRepository<Tbl_Company>
    {
        Task<List<IdNamePairRM>> GetDDLEmbroCompanyLookUp(int? CompanyID = 0, CancellationToken cancellationToken = default);
    }
}
