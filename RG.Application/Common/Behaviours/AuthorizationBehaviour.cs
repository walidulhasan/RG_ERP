using MediatR;
using Microsoft.AspNetCore.Http;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Exceptions;
using RG.Application.Common.Security;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Common.Behaviours
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationBehaviour(
            ICurrentUserService currentUserService,
            IIdentityService identityService, IHttpContextAccessor httpContextAccessor)
        {
            _currentUserService = currentUserService;
            _identityService = identityService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var authorizeAttributes = request.GetType().GetCustomAttributes<CheckAuthorizeAttribute>();
            var dd = _httpContextAccessor.HttpContext.Request;

            if (authorizeAttributes.Any())
            {
                // Must be authenticated user
                if (_currentUserService.UserID==0)
                {
                    throw new UnauthorizedAccessException();
                }

                // Role-based authorization
                var authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));

                if (authorizeAttributesWithRoles.Any())
                {
                    var authorized = false;

                    foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
                    {
                        foreach (var role in roles)
                        {
                            var isInRole = await _identityService.IsInRoleAsync(_currentUserService.UserID, role.Trim());
                            if (isInRole)
                            {
                                authorized = true;
                                break;
                            }
                        }
                    }

                    // Must be a member of at least one role in roles
                    if (!authorized)
                    {
                        throw new ForbiddenAccessException();
                    }
                }

                // Policy-based authorization
                var authorizeAttributesWithPolicies = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Policy));
                if (authorizeAttributesWithPolicies.Any())
                {
                    foreach (var policy in authorizeAttributesWithPolicies.Select(a => a.Policy))
                    {
                        var authorized = await _identityService.AuthorizeAsync(_currentUserService.UserID, policy);

                        if (!authorized)
                        {
                            throw new ForbiddenAccessException();
                        }
                    }
                }
            }

            // User is authorized / authorization not required
            return await next();
        }
    }


}
