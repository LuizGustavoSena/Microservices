using AutoMapper;
using Shopping.Api.Data.ValueObject;
using Shopping.Api.Models;

namespace Shopping.Api.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>()
                    .ReverseMap();

            });

            return mappingConfig;
        }
    }
}