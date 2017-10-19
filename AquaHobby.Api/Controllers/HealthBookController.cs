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
    public class HealthBookController : BaseController
    {
        private IHealthBookService HealthBookService;
        public HealthBookController(IHealthBookService healthBookService)
        {
            HealthBookService = healthBookService;
        }

        public async Task<HealthBook> HealthBookFullInfo(long id)
        {
            var res = await HealthBookService.GetHealthBookWithCollectionsAsync(id);
            return res;
        }
        public async Task<Observation[]> Observations(long id)
        {
            var res = await HealthBookService.GetObservationsAsync(id);
            return res;
        }
        public async Task<Illness[]> Illnesses(long id)
        {
            var res = await HealthBookService.GetIllnessesAsync(id);
            return res;
        }
        public async Task<ICollection<Nursing>> Nursings(long id)
        {
            var res = await HealthBookService.GetNursingsAsync(id);
            return res;
        }
        [HttpPost]
        public async Task<IHttpActionResult> Observation([FromBody]Observation observation, long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await HealthBookService.AddObservationAsync(observation, id, await GetCurrentId());
            return Ok(res);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Observation([FromBody]Observation observation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await HealthBookService.EditObservationAsync(observation,await GetCurrentId());
            return Ok(res);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Illness([FromBody]Illness illness, long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await HealthBookService.AddIllnessAsync(illness, id, await GetCurrentId());
            return Ok(res);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Illness([FromBody]Illness illness)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await HealthBookService.EditIllnessAsync(illness, await GetCurrentId());
            return Ok(res);
        }
      
    }
}
