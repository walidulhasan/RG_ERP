using MediatR;
using RG.Application.Contracts.Embro.Setups.BalanceSheetGroupMaps.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Embro.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.BalanceSheetGroupMaps.Queries
{
    public class GetParticularGroupsQuery : IRequest<List<ParticularGroupsRM>>
    {
        public int ParticularSerial { get; set; }
        public int GroupCategoryID { get; set; }
    }
    public class GetParticularGroupsQueryHandler : IRequestHandler<GetParticularGroupsQuery, List<ParticularGroupsRM>>
    {
        private readonly IBalanceSheetGroupMapService _balanceSheetGroupMapService;

        public GetParticularGroupsQueryHandler(IBalanceSheetGroupMapService balanceSheetGroupMapService)
        {
            _balanceSheetGroupMapService = balanceSheetGroupMapService;
        }
        public async Task<List<ParticularGroupsRM>> Handle(GetParticularGroupsQuery request, CancellationToken cancellationToken)
        {
            return await _balanceSheetGroupMapService.GetParticularGroups(request.ParticularSerial, request.GroupCategoryID, cancellationToken);
        }
    }
}
