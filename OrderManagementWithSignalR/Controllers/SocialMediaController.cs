using AutoMapper;
using Business.Abstract;
using Entities.Concrete.Pages;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.SocialMediaDto;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : ControllerBase
	{
		private readonly ISocialMediaService _socialMediaService;
		private readonly IMapper _mapper;
		public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
		{
			_socialMediaService = socialMediaService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SocialMediaList()
		{
			var value = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.GetAll());
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
		{
			var value = _mapper.Map<SocialMedia>(createSocialMediaDto);
			_socialMediaService.Add(value);
			return Ok("Sosyal Medya Bilgisi Eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteSocialMedia(int id)
		{
			var value = _socialMediaService.Get(id);
			_socialMediaService.Delete(value);
			return Ok("Sosyal Medya Bilgisi Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetSocialMedia(int id)
		{
			var value = _socialMediaService.Get(id);
			return Ok(_mapper.Map<GetSocialMediaDto>(value));
		}
		[HttpPut]
		public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
		{
			var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
			_socialMediaService.Update(value);
			return Ok("Sosyal Medya Bilgisi Güncellendi");
		}
	}
}
