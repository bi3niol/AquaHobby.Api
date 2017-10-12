﻿using AquaHobby.Models.Base;
using AquaHobby.Models.Fish;
using AquaHobby.Models.Interfaces;
using AquaHobby.Models.Photos;
using AquaHobby.Models.User;
using Bieniol.Base.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaHobby.Models
{
    public class Aquarium:AppEntity<long>, INursingable
    {
        public string Name { get; set; }
        public Size Size { get; set; }
        public List<Fish.Fish> Fish { get; set; }
        public List<WaterChange> ChangesOfWater { get; set; }
        public List<Nursing> Nursing { get; set; }

        //[ForeignKey("Photos")]
        public long? GalleryId { get; set; }
        //public Gallery Photos { get; set; }

        public Aquarium()
        {
            Fish = new List<Models.Fish.Fish>();
            ChangesOfWater = new List<WaterChange>();
            Nursing = new List<Models.Fish.Nursing>();
        }
        public void doNursing(Nursing nursing)
        {
            Nursing.Add(nursing);
            foreach (var fish in Fish)
            {
                fish.doNursing(nursing);
            }
        }
    }
}
