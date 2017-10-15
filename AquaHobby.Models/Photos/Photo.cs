using AquaHobby.Models.Base;
using AquaHobby.Models.User;
using Bieniol.Base.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AquaHobby.Models.Photos
{
    public class Photo:AppEntity<long>
    {
        public string ImageUrl { get; set; }
        public DateTime Uploaded { get; set; }

        [ForeignKey("Gallery")]
        public long GalleryId { get; set; }
        [IgnoreDataMember]
        public Gallery Gallery { get; set; }

        [ForeignKey("Aquarium")]
        public long? AquariumId { get; set; }
        [IgnoreDataMember]
        public Aquarium Aquarium { get; set; }

        [ForeignKey("Fish")]
        public long? FishId { get; set; }
        [IgnoreDataMember]
        public Fish.Fish Fish { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        [IgnoreDataMember]
        public AppUser User { get; set; }

        public Photo()
        {
            Uploaded = DateTime.Now;
        }
    }
}
