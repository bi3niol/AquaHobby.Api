using AquaHobby.DAL;
using AquaHobby.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AquaHobby.Api.Controllers
{
   // [Authorize]
    public class ValuesController : ApiController
    {
        private AppUnityOfWork UOW;
        public ValuesController(AppUnityOfWork uow)
        {
            UOW = uow;
        }
        // GET api/values
        public IEnumerable<string> Get(AppUnityOfWork uow)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id, AppUnityOfWork uow)
        {
            return "value " + id + User.ToString();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
