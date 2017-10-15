using AquaHobby.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AquaHobby.Models.Fish
{
    public class Observation:ObservableEntity<long>
    {
        [ForeignKey("HealthBook")]
        public long? HealthBookId { get; set; }
        [IgnoreDataMember]
        public HealthBook HealthBook { get; set; }
    }
}