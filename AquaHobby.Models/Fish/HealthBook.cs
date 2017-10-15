using AquaHobby.Models.Base;
using AquaHobby.Models.Interfaces;
using Bieniol.Base.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AquaHobby.Models.Fish
{
    public class HealthBook:AppEntity<long>, INursingable
    {
        public List<Illness> Illnesses { get; set; }
        public List<Observation> Observations { get; set; }
        public List<Nursing> Nursing { get; set; }

        //[ForeignKey("Fish")]
        //public long FishId { get; set; }
        //[IgnoreDataMember]
        //public Fish Fish { get; set; }

        public HealthBook():base()
        {
            Illnesses = new List<Illness>();
            Observations = new List<Observation>();
            Nursing = new List<Models.Fish.Nursing>();
        }

        public void doNursing(Nursing nursing)
        {
            nursing.HealthBookId = Id;
            Nursing.Add(nursing);
        }
    }
}
