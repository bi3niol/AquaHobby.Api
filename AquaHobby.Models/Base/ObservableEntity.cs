using System;

namespace AquaHobby.Models.Base
{
    public class ObservableEntity<TKey>:AppEntity<TKey>
    {
        public DateTime ObservationTime { get; set; }
        public string Comment { get; set; }
    }
}
