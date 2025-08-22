namespace OrderManagementSQL_API.DTOs
{
    public class InvoiceDTO
    {
        public int OrderId { get; set; }
        public List<OrderItemDTO> Items { get; set; } = new();
        public decimal TotalAmount { get; set; }
    }
}