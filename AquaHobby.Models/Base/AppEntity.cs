using AquaHobby.Models.User;
using Bieniol.Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaHobby.Models.Base
{
    public class AppEntity<Tkey>:BaseEntity<Tkey>
    {
       // [ForeignKey("Owner")]
        public string OwnerId { get; set; }
        //public AppUser Owner { get; set; }
    }
}
