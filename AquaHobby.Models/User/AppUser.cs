using AquaHobby.Models.Base;
using AquaHobby.Models.Photos;
using Bieniol.Base.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AquaHobby.Models.User
{
    public class AppUser: BaseEntity<string>
    {
        public string Name { get; set; }
        public List<Gallery> Gallery { get; set; }        
        public List<Aquarium> Aquariums { get; set; }

        [IgnoreDataMember]
        public List<Photo> ProfilePhotos { get; set; }
    }
}
