using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

		public int ActiveCategoryCount()
		{
			return _categoryDal.ActiveCategoryCount();
		}

		public void Add(Category entity)
        {
            _categoryDal.Add(entity);
        }

		public int CategoryCount()
		{
			return _categoryDal.CategoryCount();
		}

		public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category Get(int id)
        {
            return _categoryDal.Get(c=>c.CategoryID==id);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

		public int PassiveCategoryCount()
		{
			return _categoryDal.PassiveCategoryCount();
		}

		public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
