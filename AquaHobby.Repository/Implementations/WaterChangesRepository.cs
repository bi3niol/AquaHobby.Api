using AquaHobby.Models;
using Bieniol.Base.Repository;
using System.Data.Entity;

namespace AquaHobby.Repository.Implementations
{
    public class WaterChangesRepository:Repository<WaterChange,long>, IWaterChangesRepository
    {
        public WaterChangesRepository(DbContext context):base(context)
        { }
    }
}
