using Microsoft.AspNetCore.Identity;

namespace ParkNet_Ricardo.Campos.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
