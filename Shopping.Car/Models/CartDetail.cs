using System.ComponentModel.DataAnnotations.Schema;
using Shopping.Car.Models.Base;

namespace Shopping.Car.Models
{
    [Table("card_detail")]
    public class CartDetail : BaseEntity
    {
        public long CardHeaderId { get; set; }

        [ForeignKey("cart_header_id")]
        public virtual CartHeader CartHeader { get; set; }

        public long ProductId { get; set; }
        [ForeignKey("product_id")]
        public virtual Product Product { get; set; }
        public int Count { get; set; }
    }
}