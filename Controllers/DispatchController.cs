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
    public class DispatchController : Controller
    {
        private readonly ISellerService _sellerService;
        private readonly IDispatchService _dispatchService;

        public DispatchController(ISellerService sellerService, IDispatchService dispatchService)
        {
            _sellerService = sellerService;
            _dispatchService = dispatchService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> ContinueRegistration(CreateDispatchRequestModel model, string email)
        {
            var dispatch = await _dispatchService.GetByEmail(email);
            if (HttpContext.Request.Method == "POST")
            {
                if (dispatch != null)
                {
                    var newDispatch = await _dispatchService.CompleteRegisteration(model);
                    if (newDispatch.Success == true)
                    {
                        return Content(newDispatch.Message);
                    }
                    return Content(newDispatch.Message);
                }    
            }

             return View();
        }

        

        public async Task<IActionResult> ViewProfile(string email)
        {
            string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int id = int.Parse(claim);
            var profile = await _dispatchService.GetById(id);
            return View(profile);

        }

        public async Task<IActionResult> Update(UpdateDispatchRequestModel model)
        {
            string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int id = int.Parse(claim);
            var disp = await _dispatchService.GetById(id);
            if (HttpContext.Request.Method == "POST")
            {
                var seller = await _dispatchService.UpdateDispatch(model, id);
                if (seller.Success == true)
                {
                    return Content(seller.Message);
                }
                return Content(seller.Message);
            }
            return View(disp);
        }
    }
}