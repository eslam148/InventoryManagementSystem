using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventoryManagementSystem.Application.Features.Reports.DTOs;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Helpper.Mapper
{
    public class ReportProfile:  Profile
    {
        public ReportProfile()
        {
            CreateMap<Product,  LowStockProductReportDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.LowStockThreshold, opt => opt.MapFrom(src => src.LowStockThreshold))
                .ReverseMap();

            CreateMap<InventoryTransaction, ProductTransactionHistoryDto>()
               .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
               .ForMember(dest => dest.FromInventoryName, opt => opt.MapFrom(src => src.FormInventory.Name))
               .ForMember(dest => dest.ToInventoryName, opt => opt.MapFrom(src => src.ToInventory.Name))
               .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType.ToString()))
               .ReverseMap();
        }
    }
   
}
