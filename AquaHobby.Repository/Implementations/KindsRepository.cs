using AquaHobby.Models.Fish;
using Bieniol.Base.Repository;
using System.Data.Entity;

namespace AquaHobby.Repository.Implementations
{
    public class KindsRepository: Repository<Kind,long>, IKindsRepository
    {
        public KindsRepository(DbContext context):base(context)
        { }
    }
}
