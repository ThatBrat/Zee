using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zee.DTOs.RequestModels;
using Zee.Interface.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Zee.DTOs.ViewModels;
using Zee.DTOs;

namespace Zee.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        private readonly IProductService _productService;
        private readonly ICartItemService _cartItemService;
        private readonly ICartService _cartService;

        public CustomerController(ICustomerService customerService, IProductService productService, ICartItemService cartItemService, ICartService cartService)
        {
            _customerService = customerService;
            _productService = productService;
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
            return View(await _productService.GetAllProducts());

        }


        public async Task<IActionResult> Create(CreateCustomerRequestModel model)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var customer = await _customerService.Register(model);
                if (customer.Success == true)
                {
                    return Content(customer.Message);
                }
                return Content(customer.Message);
            }
            return View();
        }



        public async Task<IActionResult> ViewProfile(string email)
        {
            string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
             int id = int.Parse(claim);
            var profile = await _customerService.GetById(id);
            return View(profile);

        }

        public async Task<IActionResult> Update(UpdateCustomerRequestModel model)
        {
            string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
             int id = int.Parse(claim);
            var cus = await _customerService.GetById(id);
            if (HttpContext.Request.Method == "POST")
            {

                var customer = await _customerService.UpdateCustomer(model, id);
                if (customer.Success == true)
                {
                    return Content(customer.Message);
                }
                return Content(customer.Message);
            }
            return View(cus);
        }


        public async Task<IActionResult> ViewProduct(int productId)
        {
            var product = await _productService.GetProductById(productId);
            // var productRev = await _reviewService.CreateReviewAsync(productName);
            var model = new ProductReviewViewModel
            {
                product = product,
                Reviews = null,
            };
            return View(model);
        }

        // public async Task<IActionResult> Add(int productId)
        // {
        //     var item = await _productService.GetProductById(productId);
        //     return View(item);
        // }

         public async Task<IActionResult> AddToCart(int productId,int quantity)
        {
            var product = await _productService.GetProductById(productId);
            
            var model = new ProductCartItemViewModel
            {
                Product = product,
                CartItem = new CreateCartItemRequestModel()
                {
                    ProductName = product.Data.ProductName,
                    Price = product.Data.Price,
                    ImageUrl = product.Data.ImageUrl, 
                    Quantity = quantity  
                },
            };
            if (HttpContext.Request.Method == "POST")
            {
                string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                 int id = int.Parse(claim);
                var customer = await _customerService.GetById(id);
                var cart = await _cartService.AddToCart(model.CartItem, customer.Data.Id, productId);
                if (cart.Success == true)
                {
                    return Content(cart.Message);
                }
                return Content(cart.Message);
            }
            return View(model);
        }

       
        public async Task<IActionResult> ViewCart()
        {
                string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                 int id = int.Parse(claim);
                var customer = await _customerService.GetById(id);
                var cart = await _cartService.GetAllItems(customer.Data.Id);
                if (cart.Success == true)
                {
                    return View(cart);
                }
                return Content(cart.Message);  
        }

        public async Task<IActionResult> Delete( int cartItemId)
        {
            var cartItem = await _cartItemService.GetCartItemByCartItemIdAsync(cartItemId);
            if (cartItem== null)
                {
                    return Content("Not found");
                }
            return View(cartItem);
        }
        public async Task<IActionResult> DeleteCartItem(int  cartItemId)
        {
            var cartItem = await _cartItemService.GetCartItemByCartItemIdAsync(cartItemId);
            var result = await _cartItemService.DeleteCartItemByIdAsync(cartItemId);
                if (result.Success == true)
                {
                   
                    TempData["SuccessMessage"]=result.Message;
                    return RedirectToAction("ViewCart");
                }
            
            return RedirectToAction("ViewCart");
        }

    }
}