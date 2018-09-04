using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using System;

namespace Datalayer.Repositories
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            return request == null
                ? throw new ArgumentNullException(nameof(request))
                : request.User?.Identity?.GetUserId();
        }
    }
}
