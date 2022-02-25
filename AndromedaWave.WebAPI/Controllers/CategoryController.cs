using AndromedaWave.Models.CategoryModels;
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
    public class CategoryController : ApiController
    {
        private CategoryService CreateCategoryService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            CategoryService categoryService = new CategoryService(userId);
            return categoryService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            CategoryService categoryService = CreateCategoryService();
            var categories = categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpPost]
        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCategoryService();
            if (!service.CreateCategory(category))
                return InternalServerError();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCategoryService();
            if (!service.DeleteCategory(id))
                return InternalServerError();
            return Ok();
        }
    }
}
