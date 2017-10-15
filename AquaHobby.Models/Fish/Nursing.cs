using AquaHobby.Models.Base;
using Bieniol.Base.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AquaHobby.Models.Fish
{
    public class Nursing: ObservableEntity<long>
    {
        [ForeignKey("HealthBook")]
        public long? HealthBookId { get; set; }
        [IgnoreDataMember]
        public HealthBook HealthBook { get; set; }

        [ForeignKey("Aquarium")]
        public long? AquariumId { get; set; }
        [IgnoreDataMember]
        public Aquarium Aquarium { get; set; }

        [ForeignKey("Fish")]
        public long? FishId { get; set; }
        [IgnoreDataMember]
        public Fish Fish { get; set; }

        public string Food { get; set; }
        public decimal Quantity { get; set; }
    }
}