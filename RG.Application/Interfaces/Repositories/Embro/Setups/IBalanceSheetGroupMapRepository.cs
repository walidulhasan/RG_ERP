using RG.Application.Contracts.Embro.Setups.BalanceSheetGroupMaps.Queries.RequestResponseModel;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Embro.Setups
{
    public interface IBalanceSheetGroupMapRepository:IGenericRepository<BalanceSheetGroupMap>
    {
        Task<List<ParticularGroupsRM>> GetParticularGroups(int particularSerial, int groupCategoryID, CancellationToken cancellationToken);
    }
}
