using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MedBuy.Domain.Entities;
using MedBuy.Domain.DTOs;

namespace MedBuy.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Producto, ProductoRequestDto>();
            CreateMap<Producto, ProductoResponseDto>();
            CreateMap<ProductoRequestDto, Producto>().AfterMap(
            ((source, destination) => {
                destination.Activo = false;
            }));
            CreateMap<ProductoResponseDto, Producto>();
        }
    }
}