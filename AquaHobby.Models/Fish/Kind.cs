using AquaHobby.Models.Base;

namespace AquaHobby.Models.Fish
{
    public class Kind :AlertableEntity<long>
    {
        public string KindName { get; set; }
    }
}
