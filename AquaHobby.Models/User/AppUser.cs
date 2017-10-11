using Bieniol.Base.Models;

namespace AquaHobby.Models.User
{
    public class AppUser: BaseEntity<string>
    {
        public string Name { get; set; }
    }
}
