using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AquaHobby.Api.Models
{
    public class MoveFishToAquarium
    {
        [Required]
        public long AquariumId { get; set; }
        [Required]
        public long FishId { get; set; }
    }

    public class MovePhotoToGallery
    {
        [Required]
        public long GalleryId { get; set; }
        [Required]
        public long PhotoId { get; set; }
    }

    public class FishDied
    {
        [Required]    
        public DateTime DieTime { get; set; }
        [Required]    
        public long FishId { get; set; }
    }
}