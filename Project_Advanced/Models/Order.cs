namespace Project_Advanced.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new(); // 3emletle error bala new
      
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
    }
}
