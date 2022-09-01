using MediatR;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.UserAuthGBS.API.UserInfos.Commands
{
  public  class ChangePasswordCommand :IRequest<RResult>
    {
        
        public int UserID { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, RResult>
    {
        private readonly IIdentityService _identityService;

        public ChangePasswordCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<RResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.UserPasswordValidationWhenChange(request.UserID, request.CurrentPassword, request.NewPassword);
            return result;
        }
    }
}
