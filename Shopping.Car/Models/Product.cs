using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shopping.Car.Models.Base;

namespace Shopping.Car.Models
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string? Name { get; set; }

        [Column("price")]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Column("descriptioon")]
        [StringLength(500)]
        public string? Description { get; set; }


        [Column("category_name")]
        [StringLength(100)]
        public string? CategoryName { get; set; }


        [Column("image_url")]
        [StringLength(300)]
        public string? ImageUrl { get; set; }
    }
}