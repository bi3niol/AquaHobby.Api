using AquaHobby.Models.Photos;
using Bieniol.Base.Repository;
using System.Data.Entity;

namespace AquaHobby.Repository.Implementations
{
    public class GalleriesRepository:Repository<Gallery,long>, IGalleriesRepository
    {
        public GalleriesRepository(DbContext context):base(context)
        { }
    }
}
