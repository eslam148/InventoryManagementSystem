using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventoryManagementSystem.Application.Features.Products.Commands;
using InventoryManagementSystem.Application.Features.Products.DTOs;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Helpper.Mapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CrearteProductCommand>().ReverseMap();
            CreateMap<Product, GetProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<CrearteProductCommand, CreateProductDto>().ReverseMap();
            CreateMap<UpdateProductCommand, UpdateProductDto>().ReverseMap();
            CreateMap<UpdateProductCommand, Product>().ReverseMap();

        }
    }
}
