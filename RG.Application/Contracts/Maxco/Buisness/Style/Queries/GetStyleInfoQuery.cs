using MediatR;
using RG.Application.Contracts.Maxco.Buisness.Style.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.Style.Queries
{
    public class GetStyleInfoQuery : IRequest<StyleRM>
    {
        public long ID { get; set; }

    }
    public class GetStyleInfoQueryHandler : IRequestHandler<GetStyleInfoQuery, StyleRM>
    {
        private readonly IStyleService styleService;

        public GetStyleInfoQueryHandler(IStyleService _styleService)
        {
            styleService = _styleService;
        }
        public async Task<StyleRM> Handle(GetStyleInfoQuery request, CancellationToken cancellationToken)
        {
            return await styleService.GetStyleByID(request.ID, cancellationToken);
        }
    }
}
