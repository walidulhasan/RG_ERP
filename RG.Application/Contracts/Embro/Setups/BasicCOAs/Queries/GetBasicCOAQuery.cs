using MediatR;
using RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries
{
    public class GetBasicCOAQuery : IRequest<BasicCOARM>
    {
        public decimal ID { get; set; }
    }
    public class GetBasicCOAQueryHandler : IRequestHandler<GetBasicCOAQuery, BasicCOARM>
    {
        private readonly IBasicCOAService basicCOAService;

        public GetBasicCOAQueryHandler(IBasicCOAService _basicCOAService)
        {
            basicCOAService = _basicCOAService;
        }
        public async Task<BasicCOARM> Handle(GetBasicCOAQuery request, CancellationToken cancellationToken)
        {
            return await basicCOAService.GetBasicCOAByID(request.ID, cancellationToken);
        }
    }
}
