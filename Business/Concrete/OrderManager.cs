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
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
			_orderDal=orderDal;
		}

		public int ActiveOrderCount()
		{
			return _orderDal.ActiveOrderCount();
		}

		public void Add(Order entity)
		{
			_orderDal.Add(entity);
		}

		public void Delete(Order entity)
		{
			_orderDal.Delete(entity);
		}

		public Order Get(int id)
		{
			return _orderDal.Get(o=>o.OrderID==id);
		}

		public List<Order> GetAll()
		{
			return _orderDal.GetAll();
		}

		public decimal LastOrderPrice()
		{
			return _orderDal.LastOrderPrice();
		}

		public decimal TodayTotalPrice()
		{
			return _orderDal.TodayTotalPrice();
		}

		public int TotalOrderCount()
		{
			return _orderDal.TotalOrderCount();
		}

		public void Update(Order entity)
		{
			_orderDal.Update(entity);
		}
	}
}
