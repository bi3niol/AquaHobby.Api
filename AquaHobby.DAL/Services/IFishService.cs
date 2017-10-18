using AquaHobby.Models.Fish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaHobby.DAL.Services
{
    public interface IFishService
    {
        Fish AddFish(Fish fish, string userId);
        Task<bool> FishDied(DateTime date, long fishId, string userId);
    }
}
