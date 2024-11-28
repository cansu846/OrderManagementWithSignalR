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

		public List<Notification> GetAllNotificationByFalse()
		{
			using var context = new SignalRDbContext();
			var values =  context.Notifications.Where(n => n.Status == false);
			return values.ToList();
		}
		public int NotificationCountByStatusFalse()
		{
			using var context = new SignalRDbContext();
			var count = context.Notifications.Where(n => n.Status == false).Count();
			return count;
		}
		public void NotificationStatusChangeToFalse(int id)
		{
			using var context = new SignalRDbContext();
			var value = context.Notifications.Find(id);
			value.Status = false;
			context.SaveChanges();
		}

		public void NotificationStatusChangeToTrue(int id)
		{
			using var context = new SignalRDbContext();
			var value = context.Notifications.Find(id);
			value.Status = true;
			context.SaveChanges();
		}
	}
}
