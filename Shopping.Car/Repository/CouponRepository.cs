using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using AutoMapper;
using Shopping.Car.Data.ValueObjects;

namespace Shopping.Car.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly HttpClient _cliente;
        private IMapper _mapper;

        public CouponRepository(
            HttpClient cliente,
            IMapper mapper
        )
        {
            _cliente = cliente;
            _mapper = mapper;
        }

        public async Task<CouponVO> GetCouponByCouponCode(string couponCode, string token)
        {
            _cliente.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _cliente.GetAsync($"/api/v1/coupon/{couponCode}");

            var content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<CouponVO>(content,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}