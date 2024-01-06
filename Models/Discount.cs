namespace ShoppingAPI.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int PercentageOff { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
