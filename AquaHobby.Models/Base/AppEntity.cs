using AquaHobby.Models.User;
using Bieniol.Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AquaHobby.Models.Base
{
    public class AppEntity<Tkey>:BaseEntity<Tkey>
    {
       //[IgnoreDataMember]
        public string OwnerId { get; set; }
    }
}
