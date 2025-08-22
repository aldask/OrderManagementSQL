namespace OrderManagementSQL_API.DTOs
{
    public class InvoiceDTO
    {
        public int OrderId { get; set; }
        public List<InvoiceItemDTO> Items { get; set; } = new();
        public decimal TotalAmount { get; set; }
    }
}
