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
    [Authorize]
    public class TransactionController : ApiController
    {
        private TransactionService CreateTransactionServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            return service;
        }

        [HttpPost]
        public IHttpActionResult CreateTransaction(CreateTransaction model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateTransactionServices();

            if(!service.CreateTransaction(model))
                return InternalServerError();

            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetTransactionById(int transactionId)
        {
            var service = CreateTransactionServices();

            var transaction = service.GetTransactionById(transactionId);

            if (service.GetTransactionById(transactionId) == null)
                return BadRequest("Could not find Id");

            return Ok(transaction);

        }
        [HttpGet]
        public IHttpActionResult GetAllTransaction()
        {
            var service = CreateTransactionServices();

            var transaction = service.GetTransactions();

            return Ok(transaction);
        }
        [HttpPut]
        public IHttpActionResult UpdateTransaction(UpdateTransaction model)
        {
            var service = CreateTransactionServices();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!service.UpdateTransaction(model))
                return InternalServerError();
            return Ok(model);
        }
        [HttpDelete]
        public IHttpActionResult DeleteTransaction(int id)
        {
            var service = CreateTransactionServices();

            if(!service.DeleteTransaction(id))
                return InternalServerError();

            return Ok("Thank you! Your purchase has been cancelled");
        }
    }
}
