using MediatR;
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
    public class GetSystemNoticeQuery:IRequest<SystemNoticeRM>
    {
        public int NoticeID { get; set; }
    }
    public class GetSystemNoticeQueryHandler : IRequestHandler<GetSystemNoticeQuery, SystemNoticeRM>
    {
        private readonly ISystemNoticeService _systemNoticeService;

        public GetSystemNoticeQueryHandler(ISystemNoticeService systemNoticeService)
        {
            _systemNoticeService = systemNoticeService;
        }
        public async Task<SystemNoticeRM> Handle(GetSystemNoticeQuery request, CancellationToken cancellationToken)
        {
            return await _systemNoticeService.GetSystemNotice(request.NoticeID,cancellationToken);
        }
    }
}
