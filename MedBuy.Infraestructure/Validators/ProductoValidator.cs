using FluentValidation;
using MedBuy.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedBuy.Infraestructure.Validators
{
    public class ProductoValidator : AbstractValidator<ProductoRequestDto>
    {
       public ProductoValidator()
       {
            RuleFor(product => product.Nombre)
                .NotNull()
                .Length(5, 50);
            RuleFor(product => product.Costo)
                .NotEqual(0)
                .NotNull();
            RuleFor(product => product.Sector)
                .NotNull()
                .Length(5, 50);
       }
    }
}