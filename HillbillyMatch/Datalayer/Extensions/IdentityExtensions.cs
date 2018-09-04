using System.Security.Claims;
using System.Security.Principal;

namespace Datalayer.Extensions
{
    //Extensions to User.Identity to get more properties
    public static class IdentityExtensions
    {
        public static string GetFirstname(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Firstname");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetLastname(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Lastname");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetGender(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Gender");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

    }
}
