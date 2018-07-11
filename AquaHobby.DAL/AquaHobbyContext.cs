using AquaHobby.Models;
using AquaHobby.Models.Fish;
using AquaHobby.Models.Notyfications;
using AquaHobby.Models.Photos;
using AquaHobby.Models.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

        public AquaHobbyContext() : base("AquaHobbyContext")
        {
            //Database.SetInitializer(new MySqlInitializer());
            Database.SetInitializer<AquaHobbyContext>(new CreateDatabaseIfNotExists<AquaHobbyContext>());
            //Database.SetInitializer<AquaHobbyContext>(new DropCreateDatabaseIfModelChanges<AquaHobbyContext>());
        }
        public class MySqlInitializer : IDatabaseInitializer<AquaHobbyContext>
        {
            public void InitializeDatabase(AquaHobbyContext context)
            {
                if (!context.Database.Exists())
                {
                    // if database did not exist before - create it
                    context.Database.Create();
                }
                else
                {
                    // query to check if MigrationHistory table is present in the database
                    var migrationHistoryTableExists = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreQuery<int>(
                    string.Format(
                      "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{0}' AND table_name = '__MigrationHistory'",
                      "bi3Niol_dev_database_Aqua")).ToList();

                    // if MigrationHistory table is not there (which is the case first time we run) - create it
                    if (migrationHistoryTableExists.FirstOrDefault() == 0)
                    {
                        context.Database.Delete();
                        context.Database.Create();
                    }
                }
            }
        }
    }
}
