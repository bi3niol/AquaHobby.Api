using AquaHobby.Models.Fish;
using Bieniol.Base.Repository;
using System.Data.Entity;
using System.Threading.Tasks;

namespace AquaHobby.Repository.Implementations
{
    public class FishRepository : Repository<Fish, long>, IFishRepository
    {
        public FishRepository(DbContext context) : base(context)
        { }

        //TODO: check if it working
        //public async Task<HealthBook> GetHealthBook(long fishId)
        //{
        //    Fish fish = GetEntityAsync(fishId);
            
        //    await context.Entry(fish).Reference(f => f.HealthBook).LoadAsync();
        //    if (fish.HealthBook != null)
        //    {
        //        var entry = context.Entry(fish.HealthBook);
        //        await entry.Collection(f => f.Illnesses).LoadAsync();
        //        await entry.Collection(f => f.Nursing).LoadAsync();
        //        await entry.Collection(f => f.Observations).LoadAsync();
        //    }

        //    return fish.HealthBook;
        //}
    }
}
