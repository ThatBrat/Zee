using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;

namespace Zee.Interface.Services
{
    public interface IReviewService
    {   
        Task<BaseResponse> CreateReviewAsync(CreateReviewRequestModel model,  int productId, int customerId);
        // Task<ReviewResponseModel> GetById(int id);
        // Task<ReviewsResponseModel> GetByProductId(int id);

    }
}