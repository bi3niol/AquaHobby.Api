using AquaHobby.Models.Base;
using Bieniol.Base.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaHobby.Models.Fish
{
    public class Nursing: ObservableEntity<long>
    {
        [ForeignKey("HealthBook")]
        public long? HealthBookId { get; set; }
        public HealthBook HealthBook { get; set; }

        [ForeignKey("Aquarium")]
        public long? AquariumId { get; set; }
        public Aquarium Aquarium { get; set; }

        [ForeignKey("Fish")]
        public long? FishId { get; set; }
        public Fish Fish { get; set; }

        public string Food { get; set; }
        public decimal Quantity { get; set; }
    }
}