using AquaHobby.Models.User;
using Bieniol.Base.Repository;

namespace AquaHobby.Repository
{
    public interface IAppUsersRepository : IRepository<AppUser, string>
    {
    }
}
