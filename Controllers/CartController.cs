using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Web;
using Zee.DTOs;
using Zee.Interface.Services;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Zee.Controllers
{

    public class CartController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        private readonly ICartItemService _cartItemService;
        private readonly ICartService _cartService;

        public CartController(IUserService userService, ICustomerService customerService, ICartItemService cartItemService, ICartService cartService)
        {
            _userService = userService;
            _customerService = customerService;
            _cartItemService = cartItemService;
            _cartService = cartService;


        }

        public async Task<IActionResult> Index()
        {
            string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
             int id = int.Parse(claim);
            var customer = await _customerService.GetById(id);
            if (customer == null)
            {
                return StatusCode(406, "Customer not logged in");

            }
            return View(await _cartService.GetAllItems(customer.Data.Id));

        }


       

    }
}