using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using AndromedaWave.Data.CategoryEntity;
using AndromedaWave.Data.VenueEntity;
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

<<<<<<< HEAD
        //public DbSet<Note> Notes { get; set; } <- ANDREW and COLLIN Add your entities here!!
        ///andrew's line
        public DbSet<Venue> Venues { get; set; }
        ///andrew's line
        public DbSet<Category> Categories { get; set; }
        ///collin's line
        ///collin's line
        ///fabi's line
        ///fabi's line
=======
       
       
        
       
       
        public DbSet<Product> Products { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
>>>>>>> 6e377ae9cc8dd0cd8a51a2fd08f535aa22f1af4b

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

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
