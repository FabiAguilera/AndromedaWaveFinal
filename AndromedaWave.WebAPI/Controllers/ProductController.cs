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
    public class ProductController : ApiController
    { 
        public IHttpActionResult Post(ProductCreate product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService();

            if (!service.CreateProduct(product))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get()
        {
            ProductsService productsService = CreateProductService();
            var products = productsService.GetProducts();

            return Ok(products);
        }

        private ProductsService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var productsService = new ProductsService(userId);
            return productsService;
        }


        public IHttpActionResult Get(int id)
        {
            ProductsService productsService = CreateProductService();
            var product = productsService.GetProductById(id);
            return Ok(product);
        }

        public IHttpActionResult Put(ProductEdit product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService();

            if (!service.UpdateProduct(product))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateProductService();

            if (!service.DeleteProduct(id))
                return InternalServerError();
            return Ok();
        }
    }
}
