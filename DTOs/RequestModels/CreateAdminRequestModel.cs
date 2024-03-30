namespace Zee.DTOs.RequestModels
{
    public class CreateAdminRequestModel : CreateUserRequestModel
    {
        
        public string AccountNumber {get; set;}
    }

    public class UpdateAdminRequestModel : UpdateUserRequestModel
    {
        
         public string AccountNumber {get; set;}

    }
}
