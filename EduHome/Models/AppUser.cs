using Microsoft.AspNetCore.Identity;

namespace EduHome.Models
{
    public class AppUser:IdentityUser
    {
        internal string Role;
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsDeactive { get; set; }
    }
}
