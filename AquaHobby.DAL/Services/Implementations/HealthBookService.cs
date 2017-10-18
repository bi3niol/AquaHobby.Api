using AquaHobby.Models.Fish;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaHobby.DAL.Services.Implementations
{
    public class HealthBookService : IHealthBookService
    {
        private AppUnityOfWork UnitOfWork;
        public HealthBookService(AppUnityOfWork uof)
        {
            UnitOfWork = uof;
        }

        public async Task<HealthBook> GetHealthBookWithCollectionsAsync(long healthbookId)
        {
            var HB = await UnitOfWork.HealthBooksRepository.GetEntityAsync(healthbookId);

            if (HB != null)
            {
                var entry = UnitOfWork.context.Entry(HB);
                await entry.Collection(h => h.Illnesses).LoadAsync();
                await entry.Collection(h => h.Nursing).LoadAsync();
                await entry.Collection(h => h.Observations).LoadAsync();
            }

            return HB;
        }

        public async Task<ICollection<Observation>> GetObservationsAsync(long healthbookId)
        {
            var query = UnitOfWork.ObservationsRepository.GetEntityByExpression(o => o.HealthBookId == healthbookId);
            var observations = await query?.ToListAsync();
            return observations;
        }

        public async Task<ICollection<Illness>> GetIllnessesAsync(long healthbookId)
        {
            var query = UnitOfWork.IllnessesRepository.GetEntityByExpression(o => o.HealthBookId == healthbookId);
            var illnesses = await query?.ToListAsync();
            return illnesses;
        }

        public async Task<ICollection<Nursing>> GetNursingsAsync(long healthbookId)
        {
            var HB = await UnitOfWork.HealthBooksRepository.GetEntityAsync(healthbookId);
            if (HB == null)
                return new List<Nursing>();
            await UnitOfWork.context.Entry(HB).Collection(g => g.Nursing).LoadAsync();
            return HB.Nursing;
        }

        public async Task<long> AddObservationAsync(Observation observation, long healthbookId, string userId)
        {
            var HB = await UnitOfWork.HealthBooksRepository.GetEntityAsync(healthbookId);
            if (HB.OwnerId != userId)
                return -1;
            observation.OwnerId = userId;
            observation.HealthBookId = healthbookId;
            var obs = UnitOfWork.ObservationsRepository.Add(observation);
            return obs.Id;
        }

        public async Task<bool> EditObservationAsync(Observation observation, string userId)
        {
            if (observation == null)
                return false;
            var obs = await UnitOfWork.ObservationsRepository.GetEntityAsync(observation.Id);
            if (obs == null)
                return false;
            if (observation.HealthBookId != obs.HealthBookId)
            {
                var HB = await UnitOfWork.HealthBooksRepository.GetEntityAsync(observation.HealthBookId);
                if (HB.OwnerId != userId)
                    return false;
            }
            UnitOfWork.ObservationsRepository.Update(observation);
            UnitOfWork.Save();
            return true;
        }

        public async Task<long> AddIllnessAsync(Illness illness, long healthbookId, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditIllnessAsync(Illness illness, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
