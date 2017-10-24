using AquaHobby.Api.Models;
using AquaHobby.DAL.Services;
using AquaHobby.Models;
using AquaHobby.Models.Fish;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AquaHobby.Api.Controllers
{
    [Authorize]
    public class AquariumsController : BaseController
    {
        private IAquariumService AquariumService;
        private IFishService FishService;

        public AquariumsController(IAquariumService aquariumService,IFishService fishService)
        {
            AquariumService = aquariumService;
            FishService = fishService;
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]Aquarium aquarium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var aqua = AquariumService.CreateAquarium(aquarium, await GetCurrentId());
            return Ok(aqua);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody]Aquarium aquarium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var aqua = AquariumService.Edit(aquarium,await GetCurrentId());
            return Ok(new
            {
                Success = aqua
            });
        }

        [ActionName("Fish")]
        public async Task<Fish[]> GetFish(long id)
        {
            var res = await AquariumService.GetAllFishAsync(id);
            return res;
        }
        [HttpPost]
        [ActionName("NewFish")]
        public async Task<IHttpActionResult> AddFish([FromBody]Fish fish,long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Uid = await GetCurrentId();
            var _fish = FishService.AddFish(fish, Uid);
            var res = await AquariumService.AddFish(_fish, id, Uid);
            return Ok(_fish);
        }      
        [HttpPut]
        public async Task<IHttpActionResult> MoveFish([FromBody]MoveFishToAquarium fishToAquarium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res =await AquariumService.AddFish(fishToAquarium.FishId, fishToAquarium.AquariumId, await GetCurrentId());
            return Ok(new
            {
                Success= res
            });
        }

        [HttpPost]
        public async Task<IHttpActionResult> Nursing([FromBody]Nursing nursing,long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await AquariumService.AddNursing(nursing, id, await GetCurrentId());
            return Ok(new
            {
                Success = res
            });
        }

        [HttpPost]
        public async Task<IHttpActionResult> WaterChange([FromBody]WaterChange waterChange, long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await AquariumService.WaterChange(waterChange, id, await GetCurrentId());
            return Ok(new
            {
                Success = res
            });
        }
    }
}
