using Dto.ProductDto;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal: IGenericDal<Product>
    {
        List<ProductDetailDto> GetProductDetailWithCategory();
		int ProductCount();
        int GetProductCountByCategoryName(string name);

        List<string> GetProductNameByMinPrice();
        List<string> GetProductNameByMaxPrice();
		decimal GetAverageByProductPrice();
	}
}
