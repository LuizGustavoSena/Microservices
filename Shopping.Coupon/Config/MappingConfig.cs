using AutoMapper;

namespace Shopping.Coupon.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // config.CreateMap<ProductVO, Product>()
                //     .ReverseMap();
            });

            return mappingConfig;
        }
    }
}