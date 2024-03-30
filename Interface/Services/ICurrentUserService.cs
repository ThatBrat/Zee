using System.Security.Claims;

namespace Zee.Interface.Services
{
    public interface ICurrentUserInitializer
    {
        void SetCurrentUser(ClaimsPrincipal user);

        void SetCurrentUserId(string userId);
    }


    public interface ICurrentUser
    {
        string Name { get; }

        Guid GetUserId();

        string GetUserEmail();
        string GetFullname();
        string GetDistributorName();
        string GetDistributorId();

        bool IsAuthenticated();

        bool IsInRole(string role);
        string Role();
        IEnumerable<Claim> GetUserClaims();
    }
}