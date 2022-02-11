using AndromedaWave.Models;
using AndromedaWave.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndromedaWave.WebAPI.Controllers
{
    public class MerchantController : ApiController
    {
        public IHttpActionResult Post(MerchantCreate merchant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMerchantService();

            if (!service.CreateMerchant(merchant))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get()
        {
            MerchantService merchantService = CreateMerchantService();
            var merchants = merchantService.GetMerchants();

            return Ok(merchants);
        }

        private MerchantService CreateMerchantService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var merchantService = new MerchantService(userId);
            return merchantService;
        }


        public IHttpActionResult Get(int id)
        {
            MerchantService merchantService = CreateMerchantService();
            var merchant = merchantService.GetMerchantById(id);
            return Ok(merchant);
        }

        public IHttpActionResult Put(MerchantEdit merchant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMerchantService();

            if (!service.UpdateMerchant(merchant))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateMerchantService();

            if (!service.DeleteMerchant(id))
                return InternalServerError();
            return Ok();
        }
    }
}
