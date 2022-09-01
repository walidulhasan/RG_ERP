using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using RG.Application.Common.CommonInterfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserID;
            string userName = string.Empty;

            if (userId > 0)
            {
                userName = await _identityService.GetUserNameAsync(userId);
            }

            _logger.LogInformation("RG.ERP Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName, userId, userName, request);
        }
    }
}
