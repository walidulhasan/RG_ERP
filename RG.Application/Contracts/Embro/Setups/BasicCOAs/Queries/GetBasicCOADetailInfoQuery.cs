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
    public class GetBasicCOADetailInfoQuery:IRequest<List<BasicCOADetailRM>>
    {
        public int GroupCategoryID { get; set; }
        public string Predict { get; set; }
    }
    public class GetBasicCOADetailInfoQueryHandler : IRequestHandler<GetBasicCOADetailInfoQuery, List<BasicCOADetailRM>>
    {
        private readonly IBasicCOAService _basicCOAService;

        public GetBasicCOADetailInfoQueryHandler(IBasicCOAService basicCOAService)
        {
            _basicCOAService = basicCOAService;
        }
        public async Task<List<BasicCOADetailRM>> Handle(GetBasicCOADetailInfoQuery request, CancellationToken cancellationToken)
        {
            return await _basicCOAService.GetBasicCOADetailInfo(request.GroupCategoryID, request.Predict, cancellationToken);
        }
    }
}
