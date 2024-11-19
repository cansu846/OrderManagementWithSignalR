using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private IDiscountDal _discountDal;
        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }
        public void Add(Discount entity)
        {
            _discountDal.Add(entity);
        }

        public void Delete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public Discount Get(int id)
        {
           return _discountDal.Get(d=>d.DiscountId==id);
        }

        public List<Discount> GetAll()
        {
            return _discountDal.GetAll();   
        }

        public void Update(Discount entity)
        {
           _discountDal.Update(entity);
        }
    }
}
