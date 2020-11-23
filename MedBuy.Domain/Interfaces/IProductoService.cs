﻿using MedBuy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedBuy.Domain.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetProductos();

        Task<Producto> GetProducto(int id);

        Task AddProducto(Producto producto);

        Task UpdateProducto(Producto producto);

        Task DeleteProducto(int id);
    }
}
