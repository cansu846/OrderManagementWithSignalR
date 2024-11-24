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
	public class OrderDetailManager : IOrderDetailService
	{
		private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }
        public void Add(OrderDetail entity)
		{
			_orderDetailDal.Add(entity);
		}

		public void Delete(OrderDetail entity)
		{
			_orderDetailDal.Delete(entity);
		}

		public OrderDetail Get(int id)
		{
			return _orderDetailDal.Get(o=>o.OrderDetailID==id);
		}

		public List<OrderDetail> GetAll()
		{
			return _orderDetailDal.GetAll();
		}

		public void Update(OrderDetail entity)
		{
			_orderDetailDal.Update(entity);
		}
	}
}
