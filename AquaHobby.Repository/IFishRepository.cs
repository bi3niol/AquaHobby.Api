using AquaHobby.Models.Fish;
using Bieniol.Base.Repository;
using System.Threading.Tasks;

namespace AquaHobby.Repository
{
    public interface IFishRepository : IRepository<Fish, long>
    {
        //Task<HealthBook> GetHealthBook(long fishId);
    }
}
