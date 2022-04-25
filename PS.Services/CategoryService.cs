using PS.Domain;
using PSData;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        PSContext ctx = new PSContext();


        public void Add(Category c)
        {
            ctx.Categories.Add(c);
        }

        public void Commit()
        {
            ctx.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return ctx.Categories;
        }

        public void Remove(Category c)
        {
            ctx.Categories.Remove(c);
        }
    }
}
