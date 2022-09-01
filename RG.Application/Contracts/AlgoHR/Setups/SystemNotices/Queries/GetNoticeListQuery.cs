using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Queries
{
    public class GetNoticeListQuery:IRequest<LoadResult>
    {
        public DataSourceLoadOptions LoadOptions { get; set; }
    }
    public class GetNoticeListQueryHandler : IRequestHandler<GetNoticeListQuery, LoadResult>
    {
        private readonly ISystemNoticeService _systemNoticeService;

        public GetNoticeListQueryHandler(ISystemNoticeService systemNoticeService)
        {
            _systemNoticeService = systemNoticeService;
        }
        public async Task<LoadResult> Handle(GetNoticeListQuery request, CancellationToken cancellationToken)
        {
            var dataQuery = _systemNoticeService.GetNoticeList(cancellationToken);
            return await DataSourceLoader.LoadAsync(dataQuery, request.LoadOptions, cancellationToken);
        }
    }
}
