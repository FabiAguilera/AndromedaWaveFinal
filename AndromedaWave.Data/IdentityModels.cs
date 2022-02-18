using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace AndromedaWave.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        //public DbSet<Note> Notes { get; set; } <- ANDREW and COLLIN Add your entities here!!
        ///andrew's line
        public DbSet<Venue> Venues { get; set; }
        ///andrew's line

        //Collin's line

        //Collin's line

        public DbSet<Category> Categories { get; set; }
        ///collin's line
        ///collin's line

        ///fabi's line
        ///fabi's line





        public DbSet<Product> Products { get; set; }
        public DbSet<Merchant> Merchants { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
        //public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();
            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityuserRoleConfiguration());
        }


    }

    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }

    public class IdentityuserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityuserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}