using Bieniol.Base.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaHobby.Models.Photos
{
    public class Photo:BaseEntity<long>
    {
        public string ImageUrl { get; set; }
        public DateTime Uploaded { get; set; }
        public long GalleryId { get; set; }
        [ForeignKey("GalleryId")]
        public Gallery Gallery { get; set; }
        public Photo()
        {
            Uploaded = DateTime.Now;
        }
    }
}
