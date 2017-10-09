using AquaHobby.Models.Photos;
using Bieniol.Base.Repository;
using System.Data.Entity;

namespace AquaHobby.Repository.Implementations
{
    public class PhotosRepository: Repository<Photo,long>, IPhotosRepository
    {
        public PhotosRepository(DbContext context):base(context)
        { }
    }
}
