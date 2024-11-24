using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IOrderDal:IEntityRepository<Order>
	{
		int TotalOrderCount();
		int ActiveOrderCount();
		decimal LastOrderPrice();
		decimal TodayTotalPrice();
	}

}
