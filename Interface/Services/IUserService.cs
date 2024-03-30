using Zee.DTOs.ResponseModels;

namespace Zee.Interface.Services
{
    public interface IUserService
    {
        Task<UserResponseModel> Login(string email, string passWord);    
    }
}