using System.ComponentModel.DataAnnotations.Schema;
using Shopping.Order.Models.Base;

namespace Shopping.Order.Models
{
    [Table("order_detail")]
    public class OrderDetail : BaseEntity
    {
        public long OrderHeaderId { get; set; }

        [ForeignKey("order_header_id")]
        public virtual OrderHeader OrderHeader { get; set; }
        [Column("product_id")]
        public long ProductId { get; set; }
        [Column("count")]

        public int Count { get; set; }
        [Column("product_name")]

        public string ProductName { get; set; }
        [Column("price")]

        public decimal Price { get; set; }
    }
}