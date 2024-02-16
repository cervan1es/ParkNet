using Microsoft.AspNetCore.Identity;

namespace ParkNet_Ricardo.Campos.ViewModels
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string DriversLicense { get; set; }
        public string BankCard { get; set; }
    }
}
