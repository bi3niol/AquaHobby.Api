using AquaHobby.Models.Base;
using Bieniol.Base.Models;

namespace AquaHobby.Models.Fish
{
    public class Nursing: ObservableEntity<long>
    {
        public string Food { get; set; }
        public decimal Quantity { get; set; }
    }
}