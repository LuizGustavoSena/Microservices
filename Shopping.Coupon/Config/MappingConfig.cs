using AutoMapper;
using Shopping.Coupon.Data.ValueObjects;
using Shopping.Coupon.Models;

namespace Shopping.Coupon.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponVO, CouponC>()
                    .ReverseMap();
            });

            return mappingConfig;
        }
    }
}