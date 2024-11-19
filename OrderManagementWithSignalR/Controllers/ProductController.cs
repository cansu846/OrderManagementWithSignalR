using AutoMapper;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

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
    }
}
