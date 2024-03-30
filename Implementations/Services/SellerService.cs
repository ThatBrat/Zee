using Zee.DTOs;
using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;
using Zee.Interface.Repositories;
using Zee.Interface.Services;

namespace Zee.Implementation.Service
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IUserRepository _userRepository;
       
        public SellerService(ISellerRepository sellerRepository, IUserRepository userRepository)
        {
            _sellerRepository = sellerRepository;
            _userRepository = userRepository;
            
        }

        public async Task<BaseResponse> Register(CreateSellerRequestModel model)
        {
            var seller = await _sellerRepository.GetAsync(seller => seller.User.Email == model.Email);
            if (seller != null)
            {
                return new BaseResponse()
                {
                    Message = "Email Already Exist",
                    Success = false,
                };
            }
           
            var user = new User
            {
                Email = model.Email,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Role = Role.Seller,
                PhoneNumber = model.PhoneNumber,
                
            };
            var adduser = await _userRepository.CreateAsync(user);
            var newSeller = new Seller()
            {
                Logo = model.Logo,
                AccountNumber = model.AccountNumber,
                StoreName = model.StoreName,
                IsVerified = false,
                Address = new Address
                {
                    HouseNumber = model.Address.HouseNumber,
                    StreetName = model.Address.StreetName,
                    LGA = model.Address.LGA,
                    Town = model.Address.Town,
                    State = model.Address.State,
                    Country = model.Address.Country

                },

                UserId = adduser.Id,
            };

            var addSeller = await _sellerRepository.CreateAsync(newSeller);
            if (addSeller == null)
            {
                return new BaseResponse()
                {
                    Message = "Unable To Register Seller",
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

        public async Task<SellerResponseModel> GetById(int id)
        {
            var seller = await _sellerRepository.GetSeller(id);
            if (seller == null)
            {
                return new SellerResponseModel
                {
                    Message = "Seller not found",
                    Success = false,
                };
            }

            return new SellerResponseModel
            {
                Message = "Seller Retrived Successfully",
                Success = true,
                Data = new SellerDto
                {
                    UserDto = new UserDto
                    {
                        Id = seller.User.Id,
                        FirstName = seller.User.FirstName,
                        LastName = seller.User.LastName,
                        Email = seller.User.Email,
                        PhoneNumber = seller.User.PhoneNumber,
                        Role = seller.User.Role,
                    },
                    Logo = seller.Logo,
                    StoreName = seller.StoreName,
                    AccountNumber = seller.AccountNumber,
                    Id = seller.Id,
                    IsVerified = seller.IsVerified,
                    Address = new AddressDto
                    {
                        HouseNumber = seller.Address.HouseNumber,
                        StreetName = seller.Address.StreetName,
                        LGA = seller.Address.LGA,
                        Town = seller.Address.Town,
                        State = seller.Address.State,
                        Country = seller.Address.Country
                    } 

                }
            };
        }
        public async Task<BaseResponse> UpdateSellerAsync(UpdateSellerRequestModel updatedSeller, int id)
        {
            var seller = await _sellerRepository.GetSeller(id);
            if (seller == null)
            {
                return new BaseResponse
                {
                    Message = "Seller Not Found",
                    Success = false,
                };
            }
            seller.User.FirstName = updatedSeller.FirstName ?? seller.User.FirstName;
            seller.User.LastName = updatedSeller.LastName ?? seller.User.LastName;
            seller.User.PhoneNumber = updatedSeller.PhoneNumber ?? seller.User.PhoneNumber;
            seller.AccountNumber = updatedSeller.AccountNumber ?? seller.AccountNumber;
            seller.Logo = updatedSeller.Logo ?? seller.Logo;
            seller.StoreName = updatedSeller.StoreName ?? seller.StoreName;
            seller.Address.HouseNumber = updatedSeller.Address.HouseNumber ?? seller.Address.HouseNumber;
            seller.Address.StreetName = updatedSeller.Address.StreetName ?? seller.Address.StreetName;
            seller.Address.LGA = updatedSeller.Address.LGA ?? seller.Address.LGA;
            seller.Address.Town = updatedSeller.Address.Town ?? seller.Address.Town;
            seller.Address.State = updatedSeller.Address.State ?? seller.Address.State;
            seller.Address.Country = updatedSeller.Address.Country ?? seller.Address.Country;
            
            await _sellerRepository.UpdateAsync(seller);
            return new BaseResponse
            {
                Message = "Seller updated successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse> DeleteSellerAsync(int sellerId)
        {
            var seller = await _sellerRepository.GetAsync(x => x.Id == sellerId);
            if (seller == null)
            {
                return new BaseResponse
                {
                    Message = "seller not found",
                    Success = false,
                };
            }
            await _sellerRepository.DeleteAsync(seller);
            return new BaseResponse
            {
                Message = "seller deleted",
                Success = true,
            };
        }  
    
        public async Task<BaseResponse> VerifySellerAsync(int sellerId)
        {
            var seller = await _sellerRepository.GetAsync(x => x.Id == sellerId);
            if (seller == null)
            {
                return new BaseResponse
                {
                    Message = "seller not found",
                    Success = false,
                };
            }
            seller.IsVerified = true;
            await _sellerRepository.UpdateAsync(seller);
            return new BaseResponse
            {
                Message = "seller verified",
                Success = true,
            };
        }

         public async Task<SellersResponseModel> GetSellers()
        {
            var sellers = await _sellerRepository.GetSellers();
            if (sellers == null)
            {
                return new SellersResponseModel()
                {
                    Message = "No sellers yet",
                    Success = false,
                };
            }
            return new SellersResponseModel()
            {
                Message = "Seller(s) found",
                Success = true,
                Data = sellers.Select(x => new SellerDto()
                {
                    Id = x.Id,
                    Logo = x.Logo,
                    AccountNumber = x.AccountNumber,
                    StoreName = x.StoreName,
                    IsVerified = x.IsVerified,
                    Address = new AddressDto
                    {
                        HouseNumber = x.Address.HouseNumber,
                        StreetName = x.Address.StreetName,
                        LGA = x.Address.LGA,
                        Town = x.Address.Town,
                        State = x.Address.State,
                        Country = x.Address.Country
                    },

                    UserDto = new UserDto
                    {
                        Id = x.User.Id,
                        Email = x.User.Email,
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName,
                        PhoneNumber = x.User.PhoneNumber,
                        Role = x.User.Role,
                    },

                }).ToList(),

            };

        }
    }
}