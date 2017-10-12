using AquaHobby.Models.Base;
using AquaHobby.Models.Photos;
using Bieniol.Base.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaHobby.Models.User
{
    public class AppUser: BaseEntity<string>
    {
        public string Name { get; set; }
        public long? GalleryId { get; set; }
        
        public List<Aquarium> Aquariums { get; set; }
    }
}
