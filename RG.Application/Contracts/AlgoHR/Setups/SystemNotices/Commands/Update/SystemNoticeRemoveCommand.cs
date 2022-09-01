using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Commands.Update
{
    public class SystemNoticeRemoveCommand:IRequest<RResult>
    {
        public int NoticeID { get; set; }
    }
    public class SystemNoticeRemoveCommandHandler : IRequestHandler<SystemNoticeRemoveCommand, RResult>
    {
        private readonly ISystemNoticeService _systemNoticeService;

        public SystemNoticeRemoveCommandHandler(ISystemNoticeService systemNoticeService)
        {
            _systemNoticeService = systemNoticeService;
        }
        public async Task<RResult> Handle(SystemNoticeRemoveCommand request, CancellationToken cancellationToken)
        {
            return await _systemNoticeService.SystemNoticeDelete(request.NoticeID);
        }
    }
}
