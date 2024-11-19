using DataAccess.Abstract;
using Dto.ProductDto;
using Entities.Concrete;
using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        List<ProductDetailDto> GetProductDetailWithCategory();
    }
}
