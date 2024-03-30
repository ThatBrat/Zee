using Zee.DTOs;
using Zee.DTOs.ResponseModels;
using Zee.Interface.Repositories;
using Zee.Interface.Services;

namespace Zee.Implementation.Service
{
    public class UserService : IUserService

    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseModel> Login(string email, string passWord)
        {

            var user = await _repository.GetAsync(x => x.Email == email && x.Password == passWord);
            if (user != null)
            {
                return new UserResponseModel
                {
                        Data = new UserDto(){
                        Email = user.Email,
                        Password = user.Password,
                        Role = user.Role,
                        Id = user.Id,
                    },
                    Success = true,
                    Message = "Sucessfully logged in",
                };
            }
            return new UserResponseModel
            {
                Success = false,
                Message = "Loggin Failed",
            };
        }

        
    }
}