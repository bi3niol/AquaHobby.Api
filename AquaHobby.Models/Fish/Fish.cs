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
        public HealthBook HealthBook { get; set; }

        [ForeignKey("Kind")]
        public long? KindId { get; set; }
        public Kind Kind { get; set; }        

        [ForeignKey("Aquarium")]
        public long? AquariumId { get; set; }
        public Aquarium Aquarium { get; set; }        

        public void doNursing(Nursing nursing)
        {
            if (HealthBook != null)
            {
                HealthBook.doNursing(nursing);
            }
        }

    }
}
