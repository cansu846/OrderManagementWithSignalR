using DataAccess.Abstract;
using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfOrderDal : EfEntityRepositoryBase<Order>, IOrderDal
	{
		public EfOrderDal(SignalRDbContext context) : base(context)
		{
		}
		public int ActiveOrderCount()
		{
			using var context = new SignalRDbContext();
			return context.Orders.Where(x => x.Description == "active").Count();
		}

		public decimal LastOrderPrice()
		{
			using var context = new SignalRDbContext();
			//büyükten küçüğe sıralar
			return context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
		}

		public decimal TodayTotalPrice()
		{
			return 0;
		}

		public int TotalOrderCount()
		{
			using var context = new SignalRDbContext();
			return context.Orders.Count();
		}
	}
}
