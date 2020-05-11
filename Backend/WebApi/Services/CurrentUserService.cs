using Microsoft.AspNetCore.Http;
using QaR.Finder.Application.Common.Interfaces;
using System.Security.Claims;

namespace QaR.Finder.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}
