using AquaHobby.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AquaHobby.Models
{
    public class WaterChange: ObservableEntity<long>
    {
        [Required]
        public decimal NumberOfLiters { get; set; }

        [ForeignKey("Aquarium")]
        public long AquariumId { get; set; }
        [IgnoreDataMember]
        public Aquarium Aquarium { get; set; }
    }
}