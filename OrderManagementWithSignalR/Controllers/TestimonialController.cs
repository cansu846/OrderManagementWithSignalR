using AutoMapper;
using Business.Abstract;
using Entities.Concrete.Pages;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.TestimonialDto;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;
		private readonly IMapper _mapper;
		public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
		{
			_testimonialService = testimonialService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult TestimonialList()
		{
			var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.GetAll());
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
		{
			var value = _mapper.Map<Testimonial>(createTestimonialDto);
			_testimonialService.Add(value);
			return Ok("Müşteri Yorum Bilgisi Eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteTestimonial(int id)
		{
			var value = _testimonialService.Get(id);
			_testimonialService.Delete(value);
			return Ok("Müşteri Yorum Bilgisi Silindi");
		}

		[HttpGet("{id}")]
		public IActionResult GetTestimonial(int id)
		{
			var value = _testimonialService.Get(id);
			return Ok(_mapper.Map<GetTestimonialDto>(value));
		}

		[HttpPut]
		public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
		{
			var value = _mapper.Map<Testimonial>(updateTestimonialDto);
			_testimonialService.Update(value);
			return Ok("Müşteri Yorum Bilgisi Güncellendi");
		}
	}
}
