using AquaHobby.Models.Base;

namespace AquaHobby.Models
{
    public class WaterChange: ObservableEntity<long>
    {
        public decimal NumberOfLiters { get; set; }
    }
}