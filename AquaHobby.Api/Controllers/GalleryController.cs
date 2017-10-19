using AquaHobby.Api.Models;
using AquaHobby.DAL.Services;
using AquaHobby.Models.Photos;
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
    public class GalleryController : BaseController
    {
        private IGalleryService GalleryService;
        public GalleryController(IGalleryService galleryService)
        {
            GalleryService = galleryService;
        }

        public async Task<Gallery[]> Get()
        {
            return await GalleryService.GetGalleriesAsync();
        }

        public async Task<Gallery> Get(long id)
        {
            return await GalleryService.GetGalleryAsync(id);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]Gallery gallery)
        {
            var res = GalleryService.AddGallery(gallery,await GetCurrentId());
            return Ok(res);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody]Gallery gallery)
        {
            var res = GalleryService.Update(gallery, await GetCurrentId());
            return Ok(new { Success = res });
        }

        public async Task<Photo[]> Photos(long id)
        {
            return await GalleryService.GetGalleryPhotosAsync(id);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddPhoto([FromBody]Photo photo,long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = GalleryService.AddNewPhoto(id, await GetCurrentId(), photo);
            if (res == null)
            {
                return BadRequest("Can not add photo to this gallery...");
            }
            return Ok(res);
        }

        [HttpPost]
        public async Task<IHttpActionResult> MovePhoto([FromBody]MovePhotoToGallery moveInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = GalleryService.AddPhoto(moveInfo.GalleryId, await GetCurrentId(), moveInfo.PhotoId);

            return Ok(new { Success=res });
        }
    }
}
