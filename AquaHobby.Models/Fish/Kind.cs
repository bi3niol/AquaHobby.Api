using AquaHobby.Models.Base;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AquaHobby.Models.Fish
{
    public class Kind :AlertableEntity<long>
    {
        public string KindName { get; set; }
        [IgnoreDataMember]
        public List<Fish> Fish { get; set; }
    }
}
