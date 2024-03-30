// using System.Security.Claims;
// using Zee.Interface.Services;

// namespace Zee.Implementation.Service
// {
// public class CurrentUserService : ICurrentUser, ICurrentUserInitializer
//     {
//         private ClaimsPrincipal _user;

//         public string Name => _user.Identity.Name;

//         private Guid _userId = Guid.Empty;

//         public Guid GetUserId() =>
//             IsAuthenticated()
//                  Guid.Parse(_user.GetUserId()  Guid.Empty.ToString())
//                 : _userId;


//         public string GetUserEmail() =>
//             IsAuthenticated()
//                  _user!.GetEmail()
//                 : string.Empty;

//         public string GetDistributorId() =>
//             IsAuthenticated()
//                  _user!.GetDistributorId()
//                 : string.Empty;

//         public string GetDistributorName() =>
//             IsAuthenticated()
//                  _user!.GetDistributorName()
//                 : string.Empty;

//         public string GetFullname() =>
//             IsAuthenticated()
//                  _user!.GetFullName()
//                 : string.Empty;

//         public bool IsAuthenticated() =>
//             _user.Identity.IsAuthenticated is true;

//         public bool IsInRole(string role) =>
//             _user.IsInRole(role) is true;

//         public string Role() =>
//             IsAuthenticated()
//                  _user!.Role()
//                 : string.Empty;

//         public IEnumerable<Claim> GetUserClaims() =>
//             _user.Claims;


//         public void SetCurrentUser(ClaimsPrincipal user)
//         {
//             if (_user != null)
//             {
//                 throw new Exception("Method reserved for in-scope initialization");
//             }

//             _user = user;
//         }

//         public void SetCurrentUserId(string userId)
//         {
//             if (_userId != Guid.Empty)
//             {
//                 throw new Exception("Method reserved for in-scope initialization");
//             }

//             if (!string.IsNullOrEmpty(userId))
//             {
//                 _userId = Guid.Parse(userId);
//             }
//         }
//     }
// }