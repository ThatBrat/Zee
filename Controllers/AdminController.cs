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
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly ISellerService _sellerService;

        public AdminController(IAdminService adminService, ISellerService sellerService)
        {
            _adminService = adminService;
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Create(CreateAdminRequestModel model)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var admin = await _adminService.Register(model);
                if (admin.Success == true)
                {
                    return Content(admin.Message);
                }
                return Content(admin.Message);
            }
            return View();
        }



        public async Task<IActionResult> ViewProfile(string email)
        {
            string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
             int id = int.Parse(claim);
            var profile = await _adminService.GetById(id);
            return View(profile);

        }

        public async Task<IActionResult> Update(UpdateAdminRequestModel model)
        {
            string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
             int id = int.Parse(claim);
            var cus = await _adminService.GetById(id);
            if (HttpContext.Request.Method == "POST")
            {

                var admin = await _adminService.UpdateAdminAsync(model, id);
                if (admin.Success == true)
                {
                    return Content(admin.Message);
                }
                return Content(admin.Message);
            }
            return View(cus);
        }

        
        public async Task<IActionResult> Delete( int sellerId)
        {
            var seller = await _sellerService.GetById(sellerId);
            if (seller== null)
                {
                    return Content("Not found");
                }
            return View(seller);
        }
      
      
        public async Task<IActionResult> DeleteSeller( int sellerId)
        {
            var seller = await _sellerService.GetById(sellerId);
                var result = await _sellerService.DeleteSellerAsync(seller.Data.Id);
                if (result.Success == true)
                {
                    TempData["SuccessMessage"]=result.Message;
                    return RedirectToAction("GetAllSellers");
                }
            
            return RedirectToAction("GetAllSellers");
        }

        public async Task<IActionResult> Verify( int id)
        {
            var seller = await _sellerService.GetById(id);
            if (seller== null)
                {
                    return Content("Not found");
                }
            return View(seller);
        }

        public async Task<IActionResult> VerifySeller(int id)
        {
            var seller = await _sellerService.GetById(id);
             
           
                var result = await _sellerService.VerifySellerAsync(seller.Data.Id);
                if (result.Success == true)
                {
                    TempData["SuccessMessage"]=result.Message;
                    return RedirectToAction("GetAllSellers");
                
                }
            
           return RedirectToAction("GetAllSellers");
        }

        public async Task<IActionResult> GetAllSellers()
        {
                string claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                 int id = int.Parse(claim);
                var admin = await _adminService.GetById(id);
                var sellers = await _sellerService.GetSellers();
                if (sellers.Success == true)
                {
                    return View(sellers);
                }
                return Content(sellers.Message);  
        }

    }
}