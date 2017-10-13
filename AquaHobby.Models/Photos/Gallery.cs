using AquaHobby.Models.Base;
using AquaHobby.Models.User;
using Bieniol.Base.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaHobby.Models.Photos
{
    public class Gallery:AppEntity<long>
    {
        public string Name { get; set; }
        public ICollection<Photo> Photos { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        //[ForeignKey("Aquarium")]
        public long? AquariumId { get; set; }
        //public Aquarium Aquarium { get; set; }

    }
}
