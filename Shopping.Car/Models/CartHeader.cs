using System.ComponentModel.DataAnnotations.Schema;
using Shopping.Car.Models.Base;

namespace Shopping.Car.Models
{
    [Table("cart_header")]
    public class CartHeader : BaseEntity
    {
        [Column("user_id")]
        public string UserId { get; set; }

        [Column("coupon_code")]
        public string CouponCode { get; set; }
    }
}