using RG.Application.Contracts.Embro.Setups.BalanceSheetGroupMaps.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Services.Embro.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Setups
{
    public class BalanceSheetGroupMapService : IBalanceSheetGroupMapService
    {
        private readonly IBalanceSheetGroupMapRepository _balanceSheetGroupMapRepository;

        public BalanceSheetGroupMapService(IBalanceSheetGroupMapRepository balanceSheetGroupMapRepository)
        {
            _balanceSheetGroupMapRepository = balanceSheetGroupMapRepository;
        }
        public async Task<List<ParticularGroupsRM>> GetParticularGroups(int particularSerial, int groupCategoryID, CancellationToken cancellationToken)
        {
            return await _balanceSheetGroupMapRepository.GetParticularGroups(particularSerial, groupCategoryID, cancellationToken);
        }
    }
}
