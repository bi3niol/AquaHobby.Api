using AquaHobby.Models;
using AquaHobby.Models.Fish;
using AquaHobby.Models.Notyfications;
using AquaHobby.Models.Photos;
using AquaHobby.Models.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaHobby.DAL
{
    public class AquaHobbyContext:DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<HealthBook> HealthBooks { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Nursing> Nursings { get; set; }
        public DbSet<Observation> Observations { get; set; }

        public DbSet<KindNotyfication> KindNotyfications { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Aquarium> Aquariums { get; set; }
        public DbSet<WaterChange> WaterChanges { get; set; }

        //public AquaHobbyContext() : base("AquaHobbyContext")
        //{
        //    Database.SetInitializer<AquaHobbyContext>(new CreateDatabaseIfNotExists<AquaHobbyContext>());
        //}
    }
}
