using Microsoft.AspNetCore.Identity;
using Microsoft.Build.ObjectModelRemoting;

namespace Indigo.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
    