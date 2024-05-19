using jhyf.Data.Identity;
using Microsoft.AspNetCore.Identity;
namespace jhyf.Data.Identity
{
    public class ApplicationIdentityUser : IdentityUser
    {
        public int RoleId { get; set; }
    }
}
