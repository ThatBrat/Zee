using Microsoft.AspNetCore.Identity;

namespace Zee
{
    public class User : BaseEntity
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public string PhoneNumber {get; set;}
       
        public Role Role {get; set;}
        public Customer Customer {get; set;}
        public Seller Seller {get; set;}
        public Admin Admin {get; set;}
        public Dispatch Dispatch {get; set;}
    }
}