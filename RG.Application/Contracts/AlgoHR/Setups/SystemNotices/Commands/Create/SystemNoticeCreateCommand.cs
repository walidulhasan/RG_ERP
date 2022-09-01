using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Commands.Create
{
    public class SystemNoticeCreateCommand:IRequest<RResult>
    {
        public SystemNoticeDTM SystemNotice { get; set; }
    }
    public class SystemNoticeCreateCommandHandler : IRequestHandler<SystemNoticeCreateCommand, RResult>
    {
        private readonly ISystemNoticeService _systemNoticeService;

        public SystemNoticeCreateCommandHandler(ISystemNoticeService systemNoticeService)
        {
            _systemNoticeService = systemNoticeService;
        }
        public async Task<RResult> Handle(SystemNoticeCreateCommand request, CancellationToken cancellationToken)
        {
            return await _systemNoticeService.SystemNoticeSave(request.SystemNotice);
        }
    }
}
