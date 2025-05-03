using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventoryManagementSystem.Application.Features.Inventory.Command;
using InventoryManagementSystem.Application.Features.Inventory.DTOs;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Helpper.Mapper
{
    public class InventoryProfile:Profile
    {
        public InventoryProfile()
        {
            CreateMap<InventoryProduct, GetInventoryProductsDTO>().ReverseMap();
            CreateMap<InventoryProduct, CreateProductInverntoryCommmad>().ReverseMap();
                
        }
    }
}
