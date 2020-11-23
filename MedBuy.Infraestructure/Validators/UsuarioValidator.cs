using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FluentValidation;
using MedBuy.Domain.DTOs;

namespace MedBuy.Infraestructure.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioRequestDto>
    {
        public UsuarioValidator()
        {
            RuleFor(usuario => usuario.Nombre).NotNull().Length(3, 20);
            RuleFor(usuario => usuario.Apellido).NotNull().Length(3, 20);
        }
    }
}
