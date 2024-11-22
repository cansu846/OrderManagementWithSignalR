using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ProductDto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        private IProductService _productService;
        private IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("product-detail")]
        public IActionResult GetProductDetailWithCategory()
        {
            var values = _productService.GetProductDetailWithCategory();
            return Ok(values);
        }

		[HttpGet]
		public IActionResult GetAll()
		{
			var values = _productService.GetAll();
			return Ok(_mapper.Map<List<ResultProductDto>>(values));
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var value = _productService.Get(id);
			return Ok(value);
		}
		[HttpPost]
		public IActionResult Add(CreateProductDto createProductDto)
		{
			var value = _mapper.Map<Product>(createProductDto);
			_productService.Add(value);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult Update(UpdateProductDto updateProductDto)
		{
			var value = _mapper.Map<Product>(updateProductDto);
			_productService.Update(value);
			return Ok(Messages.Updated);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var value = _productService.Get(id);
			_productService.Delete(value);
			return Ok(Messages.Deleted);
		}
	}
}
