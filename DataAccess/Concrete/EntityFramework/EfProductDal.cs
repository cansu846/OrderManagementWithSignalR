using DataAccess.Abstract;
using Dto.ProductDto;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product>, IProductDal
    {
       
        public EfProductDal(SignalRDbContext dbContext) : base(dbContext) { }

		public decimal GetAverageByProductPrice()
		{
			using var context = new SignalRDbContext();
            var value = context.Products.Average(p=>p.Price);
            return value; 
		}

		public int GetProductCountByCategoryName(string name)
		{
            using var context = new SignalRDbContext();

            var count = (from p in context.Products
                         join c in context.Categories
                         on p.CategoryID equals c.CategoryID
                         where c.CategoryName == name
                         select p).Count();
           
            return count;
		}

		public List<ProductDetailDto> GetProductDetailWithCategory()
        {
            using (SignalRDbContext context = new SignalRDbContext()) {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryID equals c.CategoryID
                             select new ProductDetailDto
                             {
                                 ProductID = p.ProductID,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 Description=p.Description,
                                 ImageUrl = p.ImageUrl,
                                 Price = p.Price,
                                 ProductStatus = p.ProductStatus
                             };
            return result.ToList();
            }
        }

		public List<string> GetProductNameByMaxPrice()
		{
			using var context = new SignalRDbContext();

			List<string> values = new List<string>();
            var minPrice = context.Products.Max(p=>p.Price);
            values = context.Products.Where(p=>p.Price==minPrice).Select(p=>p.ProductName).ToList();
            return values;
		}

		public List<string> GetProductNameByMinPrice()
		{
			using var context = new SignalRDbContext();

			List<string> values = new List<string>();
			var minPrice = context.Products.Min(p => p.Price);
			values = context.Products.Where(p => p.Price == minPrice).Select(p => p.ProductName).ToList();
			return values;
		}

		public int ProductCount()
		{
			using var context = new SignalRDbContext();
			var count = context.Products.Count();
			return count;
		}
	}

  
}
