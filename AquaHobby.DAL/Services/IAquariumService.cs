using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaHobby.Models;
using AquaHobby.Models.Fish;

namespace AquaHobby.DAL.Services
{
    public interface IAquariumService
    {
        /// <summary>
        /// create new aquarium and set OwnerId to userId,
        /// aquarium.UserId not set
        /// </summary>
        /// <param name="aquarium"></param>
        /// <param name="userId"></param>
        /// <returns>Reference to Database object</returns>
        Aquarium CreateAquarium(Aquarium aquarium, string userId);

        /// <summary>
        /// If fish was in other aquarium, this method remove it and move to 
        /// aquarium with given id.
        /// If aquarium ownerId != userId fish is not added.
        /// Id fish ownerId != userId fish is not added.
        /// </summary>
        /// <param name="fish">reference to db object</param>
        /// <param name="userId">true if fish was added</param>
        /// <returns></returns>
        Task<bool> AddFish(Fish fish, long aquariumId, string userId);

        /// <summary>
        /// If fish was in other aquarium, this methor remove it and move to 
        /// aquarium with given id.
        /// If aquarium ownerId != userId fish is not added.
        /// Id fish ownerId != userId fish is not added.
        /// </summary>
        /// <param name="fishId"></param>
        /// <param name="userId">true if fish was added</param>
        /// <returns></returns>
        Task<bool> AddFish(long fishId, long aquariumId, string userId);

        Task<bool> Edit(Aquarium aqarium, string userId);

        Task<bool> WaterChange(DateTime date,string comment,decimal liters, long aquariumId, string userId);
        Task<bool> WaterChange(WaterChange waterChange, long aquariumId, string userId);

        Task<bool> AddNursing(DateTime date, string food, decimal Quantity, string comment, long aquariumId, string userId);
        Task<bool> AddNursing(Nursing nursing, long aquariumId, string userId);

        Task<Fish[]> GetAllFishAsync(long aquariumId);
    }
}
