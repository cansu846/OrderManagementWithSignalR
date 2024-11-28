using AutoMapper;
using Dto.NotificationDto;
using Entities.Concrete.Pages;

namespace WebApi.Mapping
{
	public class NotificationMapper:Profile
	{
		public NotificationMapper()
		{
			CreateMap<Notification, ResultNotificationDto>().ReverseMap();
			CreateMap<Notification, CreateNotificationDto>().ReverseMap();
			CreateMap<Notification, GetNotificationDto>().ReverseMap();
			CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
		}
	}
}
