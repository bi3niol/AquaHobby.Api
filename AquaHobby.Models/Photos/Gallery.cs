using Bieniol.Base.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaHobby.Models.Photos
{
    public class Gallery:BaseEntity<long>
    {
        public string Name { get; set; }
        public ICollection<Photo> Photos { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
    }
}
