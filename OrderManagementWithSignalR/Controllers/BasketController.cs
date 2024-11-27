using AutoMapper;
using Business.Abstract;
using Entities.Concrete.Pages;
using Microsoft.AspNetCore.Mvc;
using Dto.BasketDto;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController: ControllerBase
    {
        private IBasketService _basketService;
        private IMapper _mapper;
        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _basketService.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Add(CreateBasketDto createBasketDto)
        {
           var basket = _mapper.Map<Basket>(createBasketDto);
            _basketService.Add(basket);
            return Ok("Succesfullt added");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var basket = _basketService.Get(id);
            _basketService.Delete(basket);
            return Ok("Deleted");
        }

        [HttpGet("GetBasketByMenuTableId/{id}")]
        public List<ResultBasketDto> GetBasketByMenuTableId(int id)
        {
            var values = _basketService.GetBasketByMenuTableId(id);
            List<ResultBasketDto> list = _mapper.Map<List<ResultBasketDto>>(values);
            return list;
        }

            
    }
}
