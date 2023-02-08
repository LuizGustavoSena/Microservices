using AutoMapper;
using Shopping.Car.Data.ValueObject;
using Shopping.Car.Models;

namespace Shopping.Car.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>()
                    .ReverseMap();

                config.CreateMap<CartHeaderVO, CartHeader>()
                    .ReverseMap();

                config.CreateMap<CartDetailVO, CartDetail>()
                    .ReverseMap();

                config.CreateMap<CartVO, Cart>()
                                    .ReverseMap();
            });

            return mappingConfig;
        }
    }
}