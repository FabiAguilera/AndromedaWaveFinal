using AndromedaWave.Data;
using AndromedaWave.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Services
{
    public class CategoryService
    {
        public CategoryService() { }

        private readonly Guid _authorId;

        public CategoryService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateCategory(CategoryCreate model)
        {
            Category entity =
                new Category()
                {
                    AuthorId = _authorId,
                    CategoryType = model.CategoryType,
                };
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryGet> GetCategories()
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Where(p => p.AuthorId == _authorId)
                    .Select(p => new CategoryGet()
                    {
                        CategoryId = p.CategoryId,
                        CategoryType = p.CategoryType,
                    });
                return query.ToArray();
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Category Entity =
                    ctx
                    .Categories
                    .Single(p => p.CategoryId == categoryId);

                ctx.Categories.Remove(Entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
