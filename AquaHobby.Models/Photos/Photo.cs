using AquaHobby.Models.Base;
using AquaHobby.Models.User;
using Bieniol.Base.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaHobby.Models.Photos
{
    public class Photo:AppEntity<long>
    {
        public string ImageUrl { get; set; }
        public DateTime Uploaded { get; set; }

        [ForeignKey("Gallery")]
        public long GalleryId { get; set; }
        public Gallery Gallery { get; set; }

        [ForeignKey("Aquarium")]
        public long? AquariumId { get; set; }
        public Aquarium Aquarium { get; set; }

        [ForeignKey("Fish")]
        public long? FishId { get; set; }
        public Fish.Fish Fish { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public Photo()
        {
            Uploaded = DateTime.Now;
        }
    }
}
