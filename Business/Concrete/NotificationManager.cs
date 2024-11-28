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
	public class NotificationManager : INotificationService
	{
		private readonly INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void Add(Notification entity)
		{
			_notificationDal.Add(entity);
		}

		public void Delete(Notification entity)
		{
			_notificationDal.Delete(entity);
		}

		public Notification Get(int id)
		{
			return _notificationDal.Get(n=>n.NotificationID==id);
		}

		public List<Notification> GetAll()
		{
			return _notificationDal.GetAll();
		}

		public List<Notification> GetAllNotificationByFalse()
		{
			return _notificationDal.GetAllNotificationByFalse();
		}

		public int NotificationCountByStatusFalse()
		{
			return _notificationDal.NotificationCountByStatusFalse();
		}

		public void NotificationStatusChangeToFalse(int id)
		{
			_notificationDal.NotificationStatusChangeToFalse(id);
		}

		public void NotificationStatusChangeToTrue(int id)
		{
			_notificationDal.NotificationStatusChangeToTrue(id);
		}

		public void Update(Notification entity)
		{
			_notificationDal.Update(entity);	
		}
	}
}
