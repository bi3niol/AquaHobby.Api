using AquaHobby.Api.Models;
using AquaHobby.DAL.Services;
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
    public class FishController : BaseController
    {
        private IFishService FishService;
       
        public FishController(IFishService fishService)
        {
            FishService = fishService;
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody]FishDied fishDied)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await FishService.FishDied(fishDied.DieTime, fishDied.FishId,await GetCurrentId());
            return Ok(res);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Edit([FromBody]Fish fish)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await FishService.EditFish(fish, await GetCurrentId());
            return Ok(res);
        }

        public async Task<Fish> Get(long id)
        {
            return await FishService.GetFish(id);
        }
    }
}
