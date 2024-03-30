using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zee.DTOs.RequestModels;
using Zee.Interface.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Zee.Controllers
{
    public class SellerController : Controller
    {
        private readonly ISellerService _sellerService;
        private readonly IDispatchService _dispatchService;
        private readonly IProductService _productService;

        public SellerController(ISellerService sellerService, IDispatchService dispatchService, IProductService productService)
        {
            _sellerService = sellerService;
            _dispatchService = dispatchService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Create(CreateSellerRequestModel model)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var seller = await _sellerService.Register(model);
                if (seller.Success == true)
                {
                    return Content(seller.Message);
                }
                return Content(seller.Message);
            }
            return View();
        }

        public async Task<IActionResult> RegisterDispatch(RegisterDispatchRequestModel model)
        {
            if (HttpContext.Request.Method == "POST")
            {
                string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                 int id = int.Parse(claim);
                var seller = await _sellerService.GetById(id);
                var dispatch = await _dispatchService.RegisterDispatch(model, seller.Data.Id);
                if (dispatch.Success == true)
                {
                    return Content(dispatch.Message);
                }
                return Content(dispatch.Message);
            }
            return View();
        }

         public async Task<IActionResult> ViewProfile(string email)
        {
            string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
             int id = int.Parse(claim);
            var profile = await _sellerService.GetById(id);
            return View(profile);

        }

        public async Task<IActionResult> Update(UpdateSellerRequestModel model)
        {
            string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
             int id = int.Parse(claim);
            var sel = await _sellerService.GetById(id);
            if (HttpContext.Request.Method == "POST")
            {
                var seller = await _sellerService.UpdateSellerAsync(model, id);
                if (seller.Success == true)
                {
                    return Content(seller.Message);
                }
                return Content(seller.Message);
            }
            return View(sel);
        }

        public async Task<IActionResult> GetDispatches()
        {
                string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                int id = int.Parse(claim);
                var seller = await _sellerService.GetById(id);
                var dispatches = await _dispatchService.GetDispatchesBySellerId(seller.Data.Id);
                if (dispatches.Success == true)
                {
                    return View(dispatches);
                }
                return Content(dispatches.Message);  
        }

        public async Task<IActionResult> GetAllProducts()
        {
                string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                 int id = int.Parse(claim);
                var seller = await _sellerService.GetById(id);
                var products = await _productService.GetBySellerId(seller.Data.Id);
                if (products.Success == true)
                {
                    return View(products);
                }
                return Content(products.Message);  
        }

        public async Task<IActionResult> Delete( string email)
        {
            var dispatch = await _dispatchService.GetByEmail(email);
            if (dispatch== null)
                {
                    return Content("Not found");
                }
            return View(dispatch);
        }
        public async Task<IActionResult> DeleteDispatch(string  email)
        {
            var dispatch = await _dispatchService.GetByEmail(email);
            var result = await _dispatchService.DeleteDispatchAsync(dispatch.Data.UserDto.Email);
                if (result.Success == true)
                {
                   
                    TempData["SuccessMessage"]=result.Message;
                    return RedirectToAction("GetDispatches");
                }
            
            return RedirectToAction("GetDispatches");
        }
        public async Task<IActionResult> CreateProduct(CreateProductRequestModel model)
        {
            if (HttpContext.Request.Method == "POST")
            {
                string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                 int id = int.Parse(claim);
                var sel = await _sellerService.GetById(id);
                var product = await _productService.CreateProductAsync(model, sel.Data.Id);
                if (product.Success == true)
                {
                    return Content(product.Message);
                }
                return Content(product.Message);
            }
            return View();
        }


        public async Task<IActionResult> UpdateProduct(int productId, UpdateProductRequestModel model)
        {
            string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
             int id = int.Parse(claim);
            var sel = await _sellerService.GetById(id);
            var prod = await _productService.GetById(productId, sel.Data.Id);


            if (HttpContext.Request.Method == "POST")
            {

                var product = await _productService.UpdateProduct(model, prod.Data.ProductName, sel.Data.Id);
                if (product.Success == true)
                {
                    return Content(product.Message);
                }
                return Content(product.Message);
            }


            return View(prod);

        }



        

    }
}