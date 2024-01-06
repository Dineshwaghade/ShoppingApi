using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingAPI.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [ForeignKey("Customer")]

        public int CustomerId {  get; set; }
        [ForeignKey("Product")]

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int? DiscountId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
