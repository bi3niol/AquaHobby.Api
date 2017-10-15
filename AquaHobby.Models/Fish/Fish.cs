using AquaHobby.Models.Base;
using AquaHobby.Models.Interfaces;
using AquaHobby.Models.Photos;
using AquaHobby.Models.User;
using Bieniol.Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AquaHobby.Models.Fish
{
    public class Fish: AppEntity<long>, INursingable
    {
        [Required]
        public string FishName { get; set; }

        [ForeignKey("HealthBook")]
        public long HealthBookId { get; set; }
        [IgnoreDataMember]
        public HealthBook HealthBook { get; set; }

        [ForeignKey("Kind")]
        public long? KindId { get; set; }
        [IgnoreDataMember]
        public Kind Kind { get; set; }

        [ForeignKey("Aquarium")]
        public long? AquariumId { get; set; }
        [IgnoreDataMember]
        public Aquarium Aquarium { get; set; }

        [IgnoreDataMember]
        public List<Photo> Photos { get; set; }        

        public void doNursing(Nursing nursing)
        {
            if (HealthBook != null)
            {
                HealthBook.doNursing(nursing);
            }
        }

    }
}
