using AquaHobby.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaHobby.Models.Fish
{
    public class Observation:ObservableEntity<long>
    {
        [ForeignKey("HealthBook")]
        public long? HealthBookId { get; set; }
        public HealthBook HealthBook { get; set; }
    }
}