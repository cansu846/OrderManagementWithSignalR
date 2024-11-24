using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail>
	{
		public EfOrderDetailDal(SignalRDbContext context) : base(context)
		{
		}
	}
}
