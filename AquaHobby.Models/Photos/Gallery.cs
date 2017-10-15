using AquaHobby.Models.Base;
using AquaHobby.Models.User;
using Bieniol.Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AquaHobby.Models.Photos
{
    public class Gallery:AppEntity<long>
    {
        public string Name { get; set; }
        public List<Photo> Photos { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        [IgnoreDataMember]
        public AppUser User { get; set; }

        //[ForeignKey("Aquarium")]
        public long? AquariumId { get; set; }
        //public Aquarium Aquarium { get; set; }

    }
}
