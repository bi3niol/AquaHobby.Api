using AquaHobby.Models.Fish;
using Bieniol.Base.Repository;
using System.Data.Entity;

namespace AquaHobby.Repository.Implementations
{
    public class ObservationsRepository: Repository<Observation,long>, IObservationsRepository
    {
        public ObservationsRepository(DbContext context):base(context)
        { }
    }
}
