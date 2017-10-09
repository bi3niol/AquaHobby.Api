using System;

namespace AquaHobby.Models.Base
{
    public class ObservableEntity<TKey>: Bieniol.Base.Models.BaseEntity<TKey>
    {
        public DateTime ObservationTime { get; set; }
        public string Comment { get; set; }
    }
}
