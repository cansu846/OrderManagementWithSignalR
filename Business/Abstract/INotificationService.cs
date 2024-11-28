using DataAccess.Concrete;
using Entities.Concrete.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface INotificationService:IGenericService<Notification>
	{
		public List<Notification> GetAllNotificationByFalse();
		public int NotificationCountByStatusFalse();
		public void NotificationStatusChangeToFalse(int id);
		public void NotificationStatusChangeToTrue(int id);
		
	}
}
