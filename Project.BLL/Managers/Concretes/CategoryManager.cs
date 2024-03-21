using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class CategoryManager : BaseManager<Category>,ICategoryManager
    {
        ICategoryRepository _cateRep;
        public CategoryManager(ICategoryRepository catRep) :base(catRep)
        {
            _cateRep = catRep;
        }
    }
}
