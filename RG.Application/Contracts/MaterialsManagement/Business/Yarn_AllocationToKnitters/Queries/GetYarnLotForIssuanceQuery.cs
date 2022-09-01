using MediatR;
using RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries
{
    public class GetYarnLotForIssuanceQuery : IRequest<YarnLotForIssuanceRM>
    {
        public long YKNCID { get; set; }
    }
    public class GetYarnLotForIssuanceQueryHandler : IRequestHandler<GetYarnLotForIssuanceQuery, YarnLotForIssuanceRM>
    {
        private readonly IYarn_AllocationToKnitterService _yarn_AllocationToKnitterService;

        public GetYarnLotForIssuanceQueryHandler(IYarn_AllocationToKnitterService yarn_AllocationToKnitterService)
        {
            _yarn_AllocationToKnitterService = yarn_AllocationToKnitterService;
        }
        public async Task<YarnLotForIssuanceRM> Handle(GetYarnLotForIssuanceQuery request, CancellationToken cancellationToken)
        {
            return await _yarn_AllocationToKnitterService.GetYarnLotForIssuance(request.YKNCID, cancellationToken);
        }
    }
}
