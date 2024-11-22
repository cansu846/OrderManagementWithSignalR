using Business.Abstract;
using DataAccess.Abstract;
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

        public List<ProductDetailDto> GetProductDetailWithCategory()
        {
           return _productDal.GetProductDetailWithCategory();
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
