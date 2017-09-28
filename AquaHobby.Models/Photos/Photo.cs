using Bieniol.Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
