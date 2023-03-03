using WebApp.Models.Identity;

namespace WebApp.Models.Entitites
{
    public class UserProfileEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public virtual ICollection<AppIdentityUser> Users { get; set; } = new HashSet<AppIdentityUser>();
    }
}
