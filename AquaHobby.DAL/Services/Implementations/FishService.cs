using AquaHobby.Models.Fish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaHobby.DAL.Services.Implementations
{
    public class FishService : IFishService
    {
        private AppUnityOfWork UnitOfWork;
        public FishService(AppUnityOfWork uof)
        {
            UnitOfWork = uof;
        }

        public Fish AddFish(Fish fish, string userId)
        {
            if (fish == null)
                return null;
            var hb = UnitOfWork.HealthBooksRepository.Add(new HealthBook() { OwnerId = userId});
            fish.OwnerId = userId;
            fish.HealthBookId = hb.Id;
            var _fish = UnitOfWork.FishRepository.Add(fish);
            UnitOfWork.Save();
            return _fish;
        }

        public async Task<bool> FishDied(DateTime date,long fishId,string userId)
        {
            var fish = await UnitOfWork.FishRepository.GetEntityAsync(fishId);
            if (fish == null || fish.OwnerId != userId)
                return false;
            fish.DieDate = date;
            UnitOfWork.Save();
            return true;
        }
    }
}
