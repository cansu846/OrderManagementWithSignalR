using AutoMapper;
using Business.Abstract;
using Entities.Concrete.Pages;
using Microsoft.AspNetCore.Mvc;
using Dto.BasketDto;
using DataAccess.Concrete;
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
            using var context = new SignalRDbContext();
            var count = createBasketDto.Count;
            var price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault();
            _basketService.Add(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                MenuTableID = createBasketDto.MenuTableID,
                Count = count,
                Price = price,
                TotalPrice = count*price,
            });
            return Ok("Added");
        }
       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var basket = _basketService.Get(id);
            _basketService.Delete(basket);
            return Ok("Deleted");
        }

        [HttpGet("GetBasketByMenuTableId/{id}")]
        public IActionResult GetBasketByMenuTableId(int id)
        {
            var values = _basketService.GetBasketByMenuTableId(id);
            List<ResultBasketDto> list = _mapper.Map<List<ResultBasketDto>>(values);
            return Ok(list);
        }

        [HttpGet("GetBasketListByMenuTableIdWithProductName/{id}")]
        public IActionResult GetBasketListByMenuTableIdWithProductName(int id)
        {
            var values = _basketService.GetBasketListByMenuTableIdWithProductName(id);
            return Ok(values);
        }


    }
}
