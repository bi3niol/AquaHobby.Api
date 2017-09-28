using Bieniol.Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
