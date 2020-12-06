using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MedBuy.Domain.Entities;
using MedBuy.Domain.Interfaces;
using MedBuy.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedBuy.Infraestructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MedBuyContext _context;
        public ProductoRepository(MedBuyContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }
        public async Task<Producto> GetProducto(int id)
        {
            return await _context.Productos.SingleOrDefaultAsync(Producto => Producto.Id == id)
            ?? new Producto();
        }

        public async Task AddProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProducto(Producto producto)
        {
            var current = await GetProducto(producto.Id);
            current.Nombre = producto.Nombre;
            current.Costo = producto.Costo;
            var rowsUpdate = await _context.SaveChangesAsync();
            return rowsUpdate > 0;
        }

        public async Task<bool> DeleteProducto(int id)
        {
            var current = await GetProducto(id);
            _context.Productos.Remove(current);
            var rowsDelete = await _context.SaveChangesAsync();
            return rowsDelete > 0;
        }
    }
}
