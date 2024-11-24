using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRDbContext context) : base(context)
        {
        }

		public int ActiveCategoryCount()
		{
			using var context = new SignalRDbContext();
			var count = context.Categories.Where(c=>c.CategoryStatus==true).Count();
			return count;
		}

		public int CategoryCount()
		{
			using var context = new SignalRDbContext();
			var count = context.Categories.Count();
			return count;
		}

		public int PassiveCategoryCount()
		{
			using var context = new SignalRDbContext();
			var count = context.Categories.Where(c => c.CategoryStatus == false).Count();
			return count;
		}
	}
}
