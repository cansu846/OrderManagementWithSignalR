
using AutoMapper;
using Business.Abstract;
using Entities.Concrete.Pages;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.AboutDto;

namespace WebApi.Controllers
{
    //[controller] ifadesi, sınıfın adını alır (bu örnekte About), dolayısıyla bu denetleyiciye gelen
    //isteklerin rotası api/about olacaktır.
    [Route("api/[controller]")]

    //sınıfın bir API denetleyicisi olduğunu belirtir.
    [ApiController]
    public class AboutController : ControllerBase
    {
        private IAboutService _aboutService;
        private IMapper _mapper;
        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _aboutService.GetAll();
            _mapper.Map<List<ResultAboutDto>>(values);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Add(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Title = createAboutDto.Title,
                ImageUrl = createAboutDto.ImageUrl,
                Description = createAboutDto.Description,
            };
            _aboutService.Add(about);
            return Ok("Succesfullt added");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            About about = new About()
            {
                AboutId = id
            };
            _aboutService.Delete(about);
            return Ok("Deleted");
        }
        [HttpPut]
        public IActionResult Update(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutId = updateAboutDto.AboutID,
                Title = updateAboutDto.Title,
                ImageUrl = updateAboutDto.ImageUrl,
                Description = updateAboutDto.Description,
            };
            _aboutService.Update(about);
            return Ok("Updated");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) { 
            var value = _aboutService.Get(id);
            return Ok(value);
        }
    }
}