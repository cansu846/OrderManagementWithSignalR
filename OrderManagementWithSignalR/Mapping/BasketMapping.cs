using AutoMapper;
using Dto.BasketDto;
using Entities.Concrete.Pages;

namespace WebApi.Mapping
{
    public class BasketMapping:Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket, CreateBasketDto>().ReverseMap();
            CreateMap<Basket,ResultBasketDto>().ReverseMap();

        }
    }
}
