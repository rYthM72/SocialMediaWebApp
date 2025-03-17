using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SocialMediaWebApp.Utilities
{
    public static class GeneralUtility
    {
        public static string GetUsernameFromClaim(IHttpContextAccessor httpContextAccessor)
        {
            ClaimsPrincipal user = httpContextAccessor.HttpContext.User ?? throw new Exception("User not found");
            if (!user.Identity.IsAuthenticated) throw new Exception("Please Login to continue");
            var username = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName).Value;
            return username;
        }
    }
}
