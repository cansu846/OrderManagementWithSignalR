
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.CategoryDto;

namespace WebApi.Controllers
{
    //[controller] ifadesi, sınıfın adını alır (bu örnekte About), dolayısıyla bu denetleyiciye gelen
    //isteklerin rotası api/about olacaktır.
    [Route("api/[controller]")]

    //sınıfın bir API denetleyicisi olduğunu belirtir.
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _categoryService.GetAll();
            return Ok(_mapper.Map<List<ResultCategoryDto>>(values));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _categoryService.Get(id);
            return Ok(_mapper.Map<ResultCategoryDto>(value));
        }
        [HttpPost]
        public IActionResult Add(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            _categoryService.Add(value);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult Update(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.Update(value);
            return Ok(Messages.Updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _categoryService.Get(id);
            _categoryService.Delete(value);
            return Ok(Messages.Deleted);
        }

		[HttpGet("CategoryCount")]
		public IActionResult CategoryCount()
		{
			var value = _categoryService.CategoryCount();
			return Ok(value);
		}
		[HttpGet("ActiveCategoryCount")]
		public IActionResult ActiveCategoryCount()
		{
			var value = _categoryService.ActiveCategoryCount();
			return Ok(value);
		}
		[HttpGet("PassiveCategoryCount")]
		public IActionResult PassiveCategoryCount()
		{
			var value = _categoryService.PassiveCategoryCount();
			return Ok(value);
		}
	}
}