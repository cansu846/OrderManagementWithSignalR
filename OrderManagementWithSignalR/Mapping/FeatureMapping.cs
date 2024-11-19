using AutoMapper;
using Entities.Concrete.Pages;
using SignalR.DtoLayer.FeatureDto;

namespace WebApi.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<EntityFeature, ResultFeatureDto>().ReverseMap();
            CreateMap<EntityFeature, CreateFeatureDto>().ReverseMap();
            CreateMap<EntityFeature, UpdateFeatureDto>().ReverseMap();
            CreateMap<EntityFeature, GetFeatureDto>().ReverseMap();
        }
    }
}
