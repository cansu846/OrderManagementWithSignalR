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
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }
        public void Add(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void Delete(Basket entity)
        {
           _basketDal.Delete(entity);
        }

        public Basket Get(int id)
        {
           return _basketDal.Get(b=>b.BasketID==id);
        }

        public List<Basket> GetAll()
        {
            return _basketDal.GetAll();
        }

        public List<Basket> GetBasketByMenuTableId(int id)
        {
            return _basketDal.GetBasketByMenuTableId(id);
        }

        public void Update(Basket entity)
        {
            _basketDal.Update(entity);
        }
    }
}
