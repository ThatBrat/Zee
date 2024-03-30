using Zee.DTOs;
using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;
using Zee.Interface.Repositories;
using Zee.Interface.Services;

namespace Zee.Implementation.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public ReviewService(IReviewRepository reviewRepository, IUserRepository userRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _reviewRepository = reviewRepository;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;

        }

        public async Task<BaseResponse> CreateReviewAsync(CreateReviewRequestModel model, int productId, int customerId)
        {
            var review = await _reviewRepository.GetReview( productId);
            if (review != null)
            {
                return new BaseResponse()
                {
                    Message = "Review Already Exist",
                    Success = false,
                };
            }

            
            var newReview = new Review()
            {
                NoOfStars = model.NoOfStars,
                Message = model.Message,
                ProductId = productId,
                CustomerId = customerId, 
            };


            var addReview = await _reviewRepository.CreateAsync(newReview);
            if (addReview == null)
            {
                return new BaseResponse()
                {
                    Message = "Unable To Register review",
                    Success = false,
                };
            }
            else
            {

                return new BaseResponse()
                {
                    Message = "Successfully Registered",
                    Success = true,
                };
            }
        }

        // public async Task<reviewResponseModel> GetById(int id)
        // {
        //     var review = await _reviewRepository.Getreview(id);
        //     if (review == null)
        //     {
        //         return new reviewResponseModel
        //         {
        //             Message = "review not found",
        //             Success = false,
        //         };
        //     }

        //     return new reviewResponseModel
        //     {
        //         Message = "review Retrived Successfully",
        //         Success = true,
        //         Data = new reviewDto
        //         {
        //             customerDto = new customerDto
        //             {

        //                 FirstName = review.customer.FirstName,
        //                 LastName = review.customer.LastName,
        //                 Email = review.customer.Email,
        //                 PhoneNumber = review.customer.PhoneNumber,
        //                 Role = review.customer.Role,
        //             },
        //             Logo = review.Logo,
        //             StoreName = review.StoreName,
        //             AccountNumber = review.AccountNumber,
        //             Id = review.Id,
        //             Address = new AddressDto
        //             {
        //                 HouseNumber = review.Address.HouseNumber,
        //                 StreetName = review.Address.StreetName,
        //                 LGA = review.Address.LGA,
        //                 Town = review.Address.Town,
        //                 State = review.Address.State,
        //                 Country = review.Address.Country
        //             }

        //         }
        //     };
        // }
        // public async Task<BaseResponse> UpdatereviewAsync(UpdatereviewRequestModel updatedreview, int id)
        // {
        //     var review = await _reviewRepository.Getreview(id);
        //     if (review == null)
        //     {
        //         return new BaseResponse
        //         {
        //             Message = "review Not Found",
        //             Success = false,
        //         };
        //     }
        //     review.customer.FirstName = updatedreview.FirstName ?? review.customer.FirstName;
        //     review.customer.LastName = updatedreview.LastName ?? review.customer.LastName;
        //     review.customer.PhoneNumber = updatedreview.PhoneNumber ?? review.customer.PhoneNumber;
        //     review.AccountNumber = updatedreview.AccountNumber ?? review.AccountNumber;
        //     review.Logo = updatedreview.Logo ?? review.Logo;
        //     review.StoreName = updatedreview.StoreName ?? review.StoreName;
        //     review.Address.HouseNumber = updatedreview.Address.HouseNumber ?? review.Address.HouseNumber;
        //     review.Address.StreetName = updatedreview.Address.StreetName ?? review.Address.StreetName;
        //     review.Address.LGA = updatedreview.Address.LGA ?? review.Address.LGA;
        //     review.Address.Town = updatedreview.Address.Town ?? review.Address.Town;
        //     review.Address.State = updatedreview.Address.State ?? review.Address.State;
        //     review.Address.Country = updatedreview.Address.Country ?? review.Address.Country;

        //     await _reviewRepository.UpdateAsync(review);
        //     return new BaseResponse
        //     {
        //         Message = "review updated successfully",
        //         Success = true,
        //     };
        // }

        // public async Task<BaseResponse> DeletereviewAsync(int reviewId)
        // {
        //     var review = await _reviewRepository.GetAsync(x => x.Id == reviewId);
        //     if (review == null)
        //     {
        //         return new BaseResponse
        //         {
        //             Message = "review not found",
        //             Success = false,
        //         };
        //     }
        //     await _reviewRepository.DeleteAsync(review);
        //     return new BaseResponse
        //     {
        //         Message = "review deleted",
        //         Success = true,
        //     };
        // }

        // public async Task<BaseResponse> VerifyreviewAsync(int reviewId)
        // {
        //     var review = await _reviewRepository.GetAsync(x => x.Id == reviewId);
        //     if (review == null)
        //     {
        //         return new BaseResponse
        //         {
        //             Message = "review not found",
        //             Success = false,
        //         };
        //     }
        //     review.IsVerified = true;
        //     await _reviewRepository.UpdateAsync(review);
        //     return new BaseResponse
        //     {
        //         Message = "review verified",
        //         Success = true,
        //     };
        // }
    }
}