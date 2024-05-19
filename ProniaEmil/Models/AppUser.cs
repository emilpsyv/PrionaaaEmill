using Microsoft.AspNetCore.Identity;


namespace ProniaEmil.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
