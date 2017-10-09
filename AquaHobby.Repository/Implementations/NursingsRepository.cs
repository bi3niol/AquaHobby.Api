using AquaHobby.Models.Fish;
using Bieniol.Base.Repository;
using System.Data.Entity;

namespace AquaHobby.Repository.Implementations
{
    public class NursingsRepository: Repository<Nursing,long>, INursingsRepository
    {
        public NursingsRepository(DbContext context):base(context)
        { }
    }
}
