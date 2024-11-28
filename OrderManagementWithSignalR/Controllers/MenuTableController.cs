

using AutoMapper;
using Business.Abstract;
using DataAccess.Migrations;
using Dto.MenuTableDto;
using Entities.Concrete.Pages;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]

	[ApiController]
	public class MenuTableController:ControllerBase
	{
		private IMenuTableService _menuTableService;
        private readonly IMapper _mapper;

        public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

		[HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.MenuTableCount());
		}


        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _menuTableService.GetAll();
            List<ResultMenuTableDto> list = _mapper.Map<List<ResultMenuTableDto>>(values);
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Add(CreateMenuTableDto createManuTableDto)
        {
            var value = _mapper.Map<MenuTable>(createManuTableDto);
            _menuTableService.Add(value);
            return Ok("Succesfullt added");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _menuTableService.Get(id);  
            _menuTableService.Delete(value);
            return Ok("Deleted");
        }
        [HttpPut]
        public IActionResult Update(UpdateMenuTableDto updateMenuTableDto)
        {
            var value = _mapper.Map<MenuTable>(updateMenuTableDto);
            _menuTableService.Update(value);
            return Ok("Updated");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _menuTableService.Get(id);
            return Ok(value);
        }
    }
}
