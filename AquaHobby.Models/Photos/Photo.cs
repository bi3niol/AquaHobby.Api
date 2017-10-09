using Bieniol.Base.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaHobby.Models.Photos
{
    public class Photo:BaseEntity<long>
    {
        public string ImageUrl { get; set; }
        public DateTime Uploaded { get; set; }
        [ForeignKey("Gallery")]
        public long GalleryId { get; set; }
        public Photo()
        {
            Uploaded = DateTime.Now;
        }
    }
}
