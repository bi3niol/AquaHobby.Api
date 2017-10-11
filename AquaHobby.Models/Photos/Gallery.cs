using AquaHobby.Models.User;
using Bieniol.Base.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaHobby.Models.Photos
{
    public class Gallery:BaseEntity<long>
    {
        public string Name { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
    }
}
