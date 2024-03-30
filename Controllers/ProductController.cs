using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zee.DTOs.RequestModels;
using Zee.Interface.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Zee.DTOs.ResponseModels;
using Zee.DTOs.ViewModels;

namespace Zee.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISellerService _sellerService;
        private readonly IReviewService _reviewService;

        public ProductController(IProductService productService, ISellerService sellerService, IReviewService reviewService)
        {
            _productService = productService;
            _sellerService = sellerService;
            _reviewService = reviewService;
        }


        // public async Task<ActionResult> CreateReview(CreateReviewRequestModel model, int productId, int customerId)
        // {
        //     if (HttpContext.Request.Method == "POST")
        //     {
        //         // var product = _productService.GetProductById(productId);
        //         string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //         int id = int.Parse(claim);
        //         var sel = await _customerService.GetById(id);

        //         var review = await _reviewService.CreateReviewAsync(model, productId, customerId);
        //         if (review.Success == true)
        //         {
        //             return Content(review.Message);
        //         }
        //         return RedirectToAction("ViewProduct", "Product");
        //     }
        //     return View();
        // }



    }
}