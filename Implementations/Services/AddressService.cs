
using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;
using Zee.Interface.Repositories;
using Zee.Interface.Services;

namespace Zee.Implementation.Service
{
    public class AddressService : IAddressService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        public AddressService(IUserRepository userRepository, IAddressRepository addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
           
        }

         public async Task<BaseResponse> CreateAddressAsync(CreateAddressRequestModel model)
        {
            var address = new Address
            {
                HouseNumber = model.HouseNumber, 
                StreetName = model.StreetName,
                LGA = model.LGA,
                Town = model.Town,
                State = model.State,
                Country  = model.Country, 
            };

            var result = await _addressRepository.CreateAsync(address);
            return new BaseResponse
            {
                Message = "Address Created Successfully",
                Success = true,
            };
        }

        
        

           
    }
}