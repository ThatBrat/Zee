using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;

namespace Zee.Interface.Services
{
    public interface ICustomerService
    {
        Task<BaseResponse> Register(CreateCustomerRequestModel model);
        Task<CustomerResponseModel> GetById(int id);
        Task<BaseResponse> UpdateCustomer(UpdateCustomerRequestModel updatedCustomer, int id);

        

    
    }
}