using AquaHobby.Models.Fish;
using Bieniol.Base.Repository;
using System.Data.Entity;

namespace AquaHobby.Repository.Implementations
{
    public class FishRepository : Repository<Fish, long>, IFishRepository
    {
        public FishRepository(DbContext context) : base(context)
        { }
    }
}
