using AutoMapper;
using Business.Abstract;
using Dto.NotificationDto;
using Entities.Concrete.Pages;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController:ControllerBase
	{
		private INotificationService _notificationService;
		private IMapper _mapper;
		public NotificationController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var values = _notificationService.GetAll();
			return Ok(values);
		}

		[HttpGet("id")]
		public IActionResult Get(int id)
		{
			var values = _notificationService.Get(id);
			return Ok(values);
		}

		[HttpPost]
		public IActionResult Add(CreateNotificationDto createNotificationDto)
		{
			var notification = _mapper.Map<Notification>(createNotificationDto);	
			_notificationService.Add(notification);
			return Ok("Succesfullt added");
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var notification = _notificationService.Get(id);
			_notificationService.Delete(notification);
			return Ok("Deleted");
		}
		[HttpPut]
		public IActionResult Update(UpdateNotificationDto updateNotificationDto)
		{
			var notification = _mapper.Map<Notification>(updateNotificationDto);	
			_notificationService.Update(notification);
			return Ok("Updated");
		}

	}
}
