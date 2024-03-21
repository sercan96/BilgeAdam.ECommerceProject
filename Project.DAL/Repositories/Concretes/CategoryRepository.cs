using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MyContext db):base(db)
        {

        }

        public void SpecialCategoryCreation(Category category, List<Product> products)
        {
            foreach (Product item in products)
            {
                category.Products.Add(item);
            }

            _db.Categories.Add(category);
            Save();
        }
    }
}
