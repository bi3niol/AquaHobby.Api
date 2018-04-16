using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AquaHobby.Api.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Element authenticationType musi pasować do elementu zdefiniowanego w elemencie CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Dodaj tutaj niestandardowe oświadczenia użytkownika         
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
            Database.SetInitializer(new MySqlInitializer());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public class MySqlInitializer : IDatabaseInitializer<ApplicationDbContext>
        {
            public void InitializeDatabase(ApplicationDbContext context)
            {
                if (!context.Database.Exists())
                {
                    // if database did not exist before - create it
                    context.Database.Create();
                }
                else
                {
                    // query to check if MigrationHistory table is present in the database
                    var migrationHistoryTableExists = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreQuery<int>(
                    string.Format(
                      "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{0}' AND table_name = '__MigrationHistory'",
                      "bi3Niol_dev_database_Users")).ToList();

                    // if MigrationHistory table is not there (which is the case first time we run) - create it
                    if (migrationHistoryTableExists.FirstOrDefault() == 0)
                    {
                        context.Database.Delete();
                        context.Database.Create();
                    }
                }
            }
        }
    }
}