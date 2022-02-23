using System.Data.Entity.ModelConfiguration;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace AndromedaWave.Data
{

    public class IdentityuserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityuserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}