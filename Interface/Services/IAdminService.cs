using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;

namespace Zee.Interface.Services
{
    public interface IAdminService
    {
        Task<BaseResponse> Register(CreateAdminRequestModel model);
        Task<BaseResponse> UpdateAdminAsync(UpdateAdminRequestModel updatedAdmin, int id);
           

        Task<AdminResponseModel> GetById(int id);
       
        

    
    }
}