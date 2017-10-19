using AquaHobby.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AquaHobby.Models.Fish
{
    public class Nursing: ObservableEntity<long>
    {       
        public List<HealthBook> HealthBook { get; set; }

        [ForeignKey("Aquarium")]
        public long? AquariumId { get; set; }
        [IgnoreDataMember]
        public Aquarium Aquarium { get; set; }

        public string Food { get; set; }
        public decimal Quantity { get; set; }
    }
}