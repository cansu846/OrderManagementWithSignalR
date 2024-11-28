using AutoMapper;
using Dto.MenuTableDto;
using Entities.Concrete.Pages;

namespace WebApi.Mapping
{
    public class MenuTableMapper:Profile
    {
        public MenuTableMapper() { 
        CreateMap<MenuTable, ResultMenuTableDto>().ReverseMap();
        CreateMap<MenuTable, CreateMenuTableDto>().ReverseMap();
        CreateMap<MenuTable, GetMenuTableDto>().ReverseMap();
        CreateMap<MenuTable, UpdateMenuTableDto>().ReverseMap();
        }
    }
}
