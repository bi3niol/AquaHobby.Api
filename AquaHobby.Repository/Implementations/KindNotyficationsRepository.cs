using AquaHobby.Models.Notyfications;
using Bieniol.Base.Repository;
using System.Data.Entity;

namespace AquaHobby.Repository.Implementations
{
    public class KindNotyficationsRepository: Repository<KindNotyfication,long>, IKindNotyficationsRepository
    {
        public KindNotyficationsRepository(DbContext context):base(context)
        { }
    }
}
