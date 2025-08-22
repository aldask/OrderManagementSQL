using Microsoft.AspNetCore.Mvc;
using OrderManagementSQL_API.DTOs;
using OrderManagementSQL_API.Services;

namespace OrderManagementSQL_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(OrderService orderService) : ControllerBase
    {
        private readonly OrderService _orderService = orderService;

        /// <summary>
        /// Get invoice for a specific order by ID.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <returns>Order invoice with products, quantity, amount, and total amount.</returns>
        /// <response code="200">Returns the invoice for the order</response>
        /// <response code="404">If the order is not found</response>
        [HttpGet("{orderId}/invoice")]
        [ProducesResponseType(typeof(InvoiceDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<InvoiceDTO>> GetInvoice(int orderId)
        {
            var invoice = await _orderService.GetOrderInvoiceAsync(orderId);
            if (invoice == null)
            {
                return NotFound(new { Message = $"Order with ID {orderId} not found." });
            }
            return Ok(invoice);
        }
    }
}