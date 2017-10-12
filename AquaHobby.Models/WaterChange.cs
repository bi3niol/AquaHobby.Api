using AquaHobby.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaHobby.Models
{
    public class WaterChange: ObservableEntity<long>
    {
        public decimal NumberOfLiters { get; set; }

        [ForeignKey("Aquarium")]
        public long AquariumId { get; set; }
        public Aquarium Aquarium { get; set; }
    }
}