using Zee.DTOs;
using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;
using Zee.Interface.Repositories;
using Zee.Interface.Services;

namespace Zee.Implementation.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        
        public AdminService(IAdminRepository adminRepository, IUserRepository userRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
           
        }

        public async Task<BaseResponse> Register(CreateAdminRequestModel model)
        {
            var admin = await _adminRepository.GetAsync(Admin => Admin.User.Email == model.Email);
            if (admin != null)
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
                
                Role = Role.Admin,
                PhoneNumber = model.PhoneNumber,
                
            };
            var adduser = await _userRepository.CreateAsync(user);
            var newAdmin = new Admin()
            {

                UserId = adduser.Id,
                AccountNumber = model.AccountNumber,
            };

            var addAdmin = await _adminRepository.CreateAsync(newAdmin);
            if (addAdmin == null)
            {
                return new BaseResponse()
                {
                    Message = "Unable To Register Admin",
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

        public async Task<AdminResponseModel> GetById(int id)
        {
            var admin = await _adminRepository.GetAdmin(id);
            if (admin == null)
            {
                return new AdminResponseModel
                {
                    Message = "Admin not found",
                    Success = false,
                };
            }

            return new AdminResponseModel
            {
                Message = "Admin Retrived Successfully",
                Success = true,
                Data = new AdminDto
                {
                    Admin = new UserDto
                    {
                        FirstName = admin.User.FirstName,
                        LastName = admin.User.LastName,
                        Email = admin.User.Email,
                        PhoneNumber = admin.User.PhoneNumber,
                        Role = admin.User.Role,
                    },
                    Id = admin.Id,
                    AccountNumber = admin.AccountNumber,
                    

                }
            };
        }
        public async Task<BaseResponse> UpdateAdminAsync(UpdateAdminRequestModel updatedAdmin, int id)
        {
            var admin = await _adminRepository.GetAdmin(id);
            if (admin == null)
            {
                return new BaseResponse
                {
                    Message = "Admin Not Found",
                    Success = false,
                };
            }
            admin.User.FirstName = updatedAdmin.FirstName ?? admin.User.FirstName;
            admin.User.LastName = updatedAdmin.LastName ?? admin.User.LastName;
            admin.User.PhoneNumber = updatedAdmin.PhoneNumber ?? admin.User.PhoneNumber;
            admin.AccountNumber = updatedAdmin.AccountNumber ?? admin.AccountNumber;
            
           
            await _adminRepository.UpdateAsync(admin);
            return new BaseResponse
            {
                Message = "Admin updated successfully",
                Success = true,
            };
        }
    }
}