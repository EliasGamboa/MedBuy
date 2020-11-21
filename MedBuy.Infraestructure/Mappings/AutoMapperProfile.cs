using AutoMapper;
using MedBuy.Domain.DTOs;
using MedBuy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace MedBuy.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioRequestDto>();
            CreateMap<Usuario, UsuarioResponseDto>();
            CreateMap<UsuarioRequestDto, Usuario>().AfterMap(
                ((source, destination) =>
                {
                }));
            CreateMap<UsuarioResponseDto, Usuario>();
        }
    }
}
