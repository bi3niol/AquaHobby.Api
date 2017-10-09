using AquaHobby.Models.Fish;
using Bieniol.Base.Repository;
using System.Data.Entity;

namespace AquaHobby.Repository.Implementations
{
    public class IllnessesRepository:Repository<Illness,long>, IIllnessesRepository
    {
        public IllnessesRepository(DbContext context):base(context)
        { }
    }
}
