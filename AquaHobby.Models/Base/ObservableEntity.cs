using System;
using System.ComponentModel.DataAnnotations;

namespace AquaHobby.Models.Base
{
    public class ObservableEntity<TKey>:AppEntity<TKey>
    {
        [Required]
        public DateTime ObservationTime { get; set; }
        public string Comment { get; set; }
    }
}
