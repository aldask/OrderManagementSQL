using AutoMapper;
using OrderManagementSQL_API.DTOs;
using OrderManagementSQL_API.Models;

namespace OrderManagementSQL_API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, InvoiceDTO>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.Quantity * oi.Product.Price)))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));

            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Product.Category))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Quantity * src.Product.Price));
        }
    }
}