namespace Shopping.Car.Data.ValueObject
{
    public class CartVO
    {
        public CartHeaderVO? CartHeader { get; set; }
        public IEnumerable<CartDetailVO>? CartDetails { get; set; }
    }
}