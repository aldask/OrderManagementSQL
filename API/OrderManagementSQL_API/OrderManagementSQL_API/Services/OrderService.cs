using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderManagementSQL_API.Data;
using OrderManagementSQL_API.DTOs;
using Serilog;

namespace OrderManagementSQL_API.Services
{
    public class OrderService(OrderManagementDbContext context, IMapper mapper)
    {
        private readonly OrderManagementDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<InvoiceDTO?> GetOrderInvoiceAsync(int orderId)
        {
            try
            {
                var order = await _context.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.OrderItems!)
                    .ThenInclude(oi => oi.Product)
                    .FirstOrDefaultAsync(o => o.Id == orderId);

                if (order == null)
                {
                    Log.Warning("Order with ID {OrderId} not found.", orderId);
                    return null;
                }

                var invoiceDto = _mapper.Map<InvoiceDTO>(order);

                Log.Information(
                    "Invoice retrieved for Order {OrderId}. TotalAmount: {TotalAmount}",
                    orderId,
                    invoiceDto.TotalAmount
                );

                return invoiceDto;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving invoice for Order {OrderId}", orderId);
                throw;
            }
        }
    }
}