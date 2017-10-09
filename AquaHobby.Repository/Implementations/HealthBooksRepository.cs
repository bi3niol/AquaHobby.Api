using AquaHobby.Models.Fish;
using Bieniol.Base.Repository;
using System.Data.Entity;

namespace AquaHobby.Repository.Implementations
{
    public class HealthBooksRepository: Repository<HealthBook,long>, IHealthBooksRepository
    {
        public HealthBooksRepository(DbContext context):base(context)
        { }
    }
}
