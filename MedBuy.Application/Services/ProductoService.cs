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
        private readonly IUnitOfWork _unitOfWork;

        public ProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddProducto(Producto producto)
        {
            Expression<Func<Producto, bool>> exprProducto = item => item.Nombre == producto.Nombre;
            var productos = await _unitOfWork.ProductoRepository.FindByCondition(exprProducto);
        }

        public async Task DeleteProducto(int id)
        {
            await _unitOfWork.ProductoRepository.Delete(id);
        }

        public async Task<Producto> GetProducto(int id)
        {
            return await _unitOfWork.ProductoRepository.GetById(id);
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _unitOfWork.ProductoRepository.GetAll();
        }

        public async Task UpdateProducto(Producto producto)
        {
            await _unitOfWork.ProductoRepository.Update(producto);
        }
    }
}
