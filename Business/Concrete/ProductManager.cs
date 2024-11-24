using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Dto.ProductDto;
using Entities.Concrete;
using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product entity)
        {
            _productDal.Add(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product Get(int id)
        {
            return _productDal.Get(p=>p.ProductID==id);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

		public decimal GetAverageByProductPrice()
		{
			return _productDal.GetAverageByProductPrice();
		}

		public int GetProductCountByCategoryName(string name)
		{
            return _productDal.GetProductCountByCategoryName(name);
		}

		public List<ProductDetailDto> GetProductDetailWithCategory()
        {
           return _productDal.GetProductDetailWithCategory();
		}

		public List<string> GetProductNameByMaxPrice()
		{
			return _productDal.GetProductNameByMaxPrice();
		}

		public List<string> GetProductNameByMinPrice()
		{
			return _productDal.GetProductNameByMinPrice();

		}

		public int ProductCount()
		{
			return _productDal.ProductCount();

		}

		public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
