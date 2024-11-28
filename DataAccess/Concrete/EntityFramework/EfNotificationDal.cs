using DataAccess.Abstract;
using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfNotificationDal : EfEntityRepositoryBase<Notification>, INotificationDal
	{
		public EfNotificationDal(SignalRDbContext context) : base(context)
		{
		}
	}
}
