using MedBuy.Domain.Entities;
using MedBuy.Domain.Interfaces;
using MedBuy.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MedBuy.Infraestructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly MedBuyContext _context;
        public PedidoRepository(MedBuyContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Pedido>> GetPedidos()
        {
            return await _context.Pedidos.Include(p => p.PedidoProductos).ToListAsync();
        }
        public async Task<Pedido> GetPedido(int id)
        {
            return await _context.Pedidos.Include(p => p.PedidoProductos).SingleOrDefaultAsync(Pedido => Pedido.PedidoId == id)
            ?? new Pedido();
        }

        public async Task AddPedido(Pedido pedido)
        {
            _context.Entry(pedido).State = EntityState.Added;
            foreach (var c in pedido.Productos)
                _context.Entry(c).State = EntityState.Unchanged;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePedido(Pedido pedido)
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM PedidoProducto WHERE PedidoID = @id",
                 new SqlParameter("id", pedido.PedidoId));

            var Detalle = pedido.Productos;

            pedido.Productos = null;
            _context.Entry(pedido).State = EntityState.Modified;
            pedido.Productos = Detalle;
            foreach (var c in pedido.Productos)
                _context.Entry(c).State = EntityState.Unchanged;

            var rowsUpdate = await _context.SaveChangesAsync();
            return rowsUpdate > 0;
        }

        public async Task<bool> DeletePedido(int id)
        {
            var current = await GetPedido(id);
            _context.Pedidos.Remove(current);
            var rowsDelete = await _context.SaveChangesAsync();
            return rowsDelete > 0;
        }
    }
}
