using AquaHobby.Models.Fish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaHobby.DAL.Services
{
    public interface IHealthBookService
    {
        Task<HealthBook> GetHealthBookWithCollectionsAsync(long healthbookId);
        Task<ICollection<Observation>> GetObservationsAsync(long healthbookId);
        Task<ICollection<Illness>> GetIllnessesAsync(long healthbookId);
        Task<ICollection<Nursing>> GetNursingsAsync(long healthbookId);

        Task<long> AddObservationAsync(Observation observation, long healthbookId, string userId);
        Task<bool> EditObservationAsync(Observation observation, string userId);

        Task<long> AddIllnessAsync(Illness illness, long healthbookId, string userId);
        Task<bool> EditIllnessAsync(Illness illness, string userId);
    }
}
