namespace OrderManagementSQL_API.DTOs
{
    public class InvoiceItemDTO
    {
        public string? ProductName { get; set; }
        public string? Category { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
