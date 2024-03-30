// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Authentication.Cookies;
// using Microsoft.AspNetCore.Mvc;
// using System.Security.Claims;
// using System.Web;
// using Zee.Interface.Services;
// using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
// namespace Zee.Controllers
// {

//     public class ReviewController : Controller
//     {
//         private readonly IReviewService _reviewService;
//         private readonly IProductService _productService;
//         private readonly ICustomerService _customerService;
       

//         public ReviewController(IReviewService reviewService, ICustomerService customerService, IProductService productService)
//         {
//             _reviewService = reviewService;
//             _customerService = customerService;
//             _productService = productService;
//         }

//         public async Task<IActionResult> Create(CreateReviewRequestModel model, int productId)
//         {
//             if (HttpContext.Request.Method == "POST")
//             {
//                 string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
//                 int id = int.Parse(claim);
//                 var sel = await _sellerService.GetById(id);
//                 var product = await _productService.CreateProductAsync(model , sel.Data.Id);
//             }
//             return View();
//         }





        
        

        




//     }
// }
