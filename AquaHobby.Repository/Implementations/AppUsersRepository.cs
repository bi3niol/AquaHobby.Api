using AquaHobby.Models.User;
using Bieniol.Base.Repository;
using System.Data.Entity;

namespace AquaHobby.Repository.Implementations
{
    public class AppUsersRepository : Repository<AppUser, string>, IAppUsersRepository
    {
        public AppUsersRepository(DbContext context):base(context)
        { }
    }
}
