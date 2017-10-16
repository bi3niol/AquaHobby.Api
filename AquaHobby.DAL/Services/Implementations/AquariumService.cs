using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaHobby.Models;
using AquaHobby.Models.Fish;
using System.Data.Entity;

namespace AquaHobby.DAL.Services.Implementations
{
    public class AquariumService : IAquariumService
    {
        private AppUnityOfWork UnitOfWork;
        public AquariumService(AppUnityOfWork uof)
        {
            UnitOfWork = uof;
        }

        public async Task<bool> AddFish(Fish fish, long aquariumId, string userId)
        {
            if (fish == null || fish.OwnerId != userId)
                return false;
            var aqua = await UnitOfWork.AquariumsRepository.
                GetEntityByExpression(a => a.Id == aquariumId).
                Select(a => new { a.OwnerId }).
                FirstOrDefaultAsync();
            if (aqua == null || aqua.OwnerId!=userId)
                return false;
            fish.AquariumId = aquariumId;
            UnitOfWork.Save();
            return true;
        }

        public async Task<bool> AddFish(long fishId, long aquariumId, string userId)
        {
            return await AddFish(UnitOfWork.FishRepository.GetEntity(fishId), aquariumId, userId);
        }

        public async Task<bool> AddNursing(DateTime date, string food, decimal quantity, string comment, long aquariumId, string userId)
        {
            var nursing = new Nursing()
            {
                Food=food,
                Quantity=quantity,
                Comment = comment                
            };
            return await AddNursing(nursing, aquariumId, userId);
        }

        public async Task<bool> AddNursing(Nursing nursing, long aquariumId, string userId)
        {
            var aqua = UnitOfWork.AquariumsRepository.GetEntity(aquariumId);
            if (aqua == null || aqua.OwnerId != userId)
                return false;
            await UnitOfWork.context.Entry(aqua).Collection(a => a.Fish).LoadAsync();
            //await UnitOfWork.context.Entry(aqua).Collection(a => a.Nursing).LoadAsync(); //probably dont neet load collection from db TODO: check it
            nursing.OwnerId = userId;
            nursing.AquariumId = aquariumId;
            var nurs = UnitOfWork.NursingsRepository.Add(nursing);
            if (aqua.Nursing == null)
                aqua.Nursing = new List<Nursing>();
            aqua.Nursing.Add(nurs);
            foreach (var fish in aqua.Fish)
            {
                await UnitOfWork.context.Entry(fish).Reference(f => f.HealthBook).LoadAsync();
                if (fish.HealthBook != null)
                {
                    if (fish.HealthBook.Nursing == null)
                        fish.HealthBook.Nursing = new List<Nursing>();
                    fish.HealthBook.Nursing.Add(nurs);
                }
            }
            UnitOfWork.Save();
            return true;
        }

        public Aquarium CreateAquarium(Aquarium aquarium, string userId)
        {
            aquarium.OwnerId = userId;
            aquarium.UserId = userId;
            var aqua = UnitOfWork.AquariumsRepository.Add(aquarium);
            UnitOfWork.Save();
            return aqua;
        }

        public bool WaterChange(DateTime date, string comment, decimal liters, long aquariumId, string userId)
        {
            var waterchange = new WaterChange()
            {
                ObservationTime = date,
                Comment = comment,
                NumberOfLiters = liters
            };
            return WaterChange(waterchange, aquariumId, userId);
        }

        public bool WaterChange(WaterChange waterChange, long aquariumId, string userId)
        {
            var aqua = UnitOfWork.AquariumsRepository.GetEntity(aquariumId);
            if (aqua == null || aqua.OwnerId != userId)
                return false;
            waterChange.OwnerId = userId;
            var wCh = UnitOfWork.WaterChangesRepository.Add(waterChange);
            UnitOfWork.Save();
            return true;
        }
    }
}
