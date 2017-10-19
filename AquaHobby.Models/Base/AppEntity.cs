using Bieniol.Base.Models;

namespace AquaHobby.Models.Base
{
    public class AppEntity<Tkey>:BaseEntity<Tkey>
    {
       //[IgnoreDataMember]
        public string OwnerId { get; set; }
    }
}
