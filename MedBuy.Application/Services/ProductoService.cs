using MedBuy.Domain.Entities;
using MedBuy.Domain.Interfaces;
using MedBuy.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedBuy.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            this._repository = repository;
        }
        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _repository.GetProductos();
        }
        public async Task<Producto> GetProducto(int id)
        {
            return await _repository.GetProducto(id);
        }

        public async Task AddProducto(Producto producto)
        {
            await _repository.AddProducto(producto);
        }

        public async Task<bool> UpdateProducto(Producto producto)
        {
            return await _repository.UpdateProducto(producto);
        }

        public async Task<bool> DeleteProducto(int id)
        {
            return await _repository.DeleteProducto(id);
        }
    }
}
