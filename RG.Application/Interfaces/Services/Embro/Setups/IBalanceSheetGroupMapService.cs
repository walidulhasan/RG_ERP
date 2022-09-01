using RG.Application.Contracts.Embro.Setups.BalanceSheetGroupMaps.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Setups
{
    public interface IBalanceSheetGroupMapService
    {
        Task<List<ParticularGroupsRM>> GetParticularGroups(int particularSerial, int groupCategoryID, CancellationToken cancellationToken);
    }
}
