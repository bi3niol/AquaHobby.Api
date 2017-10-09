using AquaHobby.Models.Interfaces;
using Bieniol.Base.Models;
using System.Collections.Generic;

namespace AquaHobby.Models.Fish
{
    public class HealthBook:BaseEntity<long>, INursingable
    {
        public List<Illness> Illnesses { get; set; }
        public List<Observation> Observations { get; set; }
        public List<Nursing> Nursing { get; set; }

        public HealthBook():base()
        {
            Illnesses = new List<Illness>();
            Observations = new List<Observation>();
            Nursing = new List<Models.Fish.Nursing>();
        }

        public void doNursing(Nursing nursing)
        {
            Nursing.Add(nursing);
        }
    }
}
