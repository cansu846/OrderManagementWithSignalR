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

        public List<ProductDetailDto> GetProductDetailWithCategory()
        {
            using (SignalRDbContext context = new SignalRDbContext()) {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.Name,
                                 CategoryName = c.Name
                             };
            return result.ToList();
            }
        }
    }

  
}
