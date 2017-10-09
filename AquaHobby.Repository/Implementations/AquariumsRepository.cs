using AquaHobby.Models;
using Bieniol.Base.Repository;
using System.Data.Entity;

namespace AquaHobby.Repository.Implementations
{
    public class AquariumsRepository: Repository<Aquarium,long>, IAquariumsRepository
    {
        public AquariumsRepository(DbContext context):base(context)
        { }
    }
}
