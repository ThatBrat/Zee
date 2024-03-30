using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;

namespace Zee.Interface.Services
{
    public interface IDispatchService
    {
        Task<BaseResponse> CompleteRegisteration(CreateDispatchRequestModel model);
        Task<DispatchResponseModel> GetById(int id);
        Task<DispatchResponseModel> GetByEmail(string email);
        Task<BaseResponse> UpdateDispatch(UpdateDispatchRequestModel updatedDispatch, int id);    
        Task<BaseResponse> RegisterDispatch(RegisterDispatchRequestModel model, int sellerId);  
        Task<DispatchesResponseModel> GetDispatchesBySellerId(int sellerId);    
        Task<BaseResponse> DeleteDispatchAsync(string email);
    
  
    }
}