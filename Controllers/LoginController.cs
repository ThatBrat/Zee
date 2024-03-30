using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Web;
using Zee.Interface.Services;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Zee.Controllers
{

    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;


        }



        public async Task<IActionResult> SignIn(string email, string password)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var login = await _userService.Login(email, password);
                if (!login.Success)
                {
                    TempData["Message"]="Email or Password is incorrect";
                    return View();
                }
               
                var claims = new List<Claim>
                {
                    new Claim (ClaimTypes.NameIdentifier, login.Data.Id.ToString()),
                    new Claim (ClaimTypes.Email, login.Data.Email),
                    new Claim (ClaimTypes.Name, login.Data.Password),
                    new Claim (ClaimTypes.Role, login.Data.Role.ToString()),

                };



                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                if (login.Data.Role == Role.Customer)
                {
                    return RedirectToAction("Index", "Customer");
                }
                else if (login.Data.Role == Role.Seller)
                {
                    return RedirectToAction("Index", "Seller");
                }
                else if (login.Data.Role == Role.Admin)
                {
                    return RedirectToAction("Index", "Admin");
                }
                
            }
            return View();

        }
        

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn");
        }




    }
}
