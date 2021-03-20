using MedBuy.Domain.Entities;
using MedBuy.Domain.Interfaces;
using MedBuy.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            return await _context.Pedidos.ToListAsync();
        }
        public async Task<Pedido> GetPedido(int id)
        {
            return await _context.Pedidos.SingleOrDefaultAsync(Pedido => Pedido.PedidoId == id)
            ?? new Pedido();
        }

        public async Task AddPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePedido(Pedido pedido)
        {
            var current = await GetPedido(pedido.PedidoId);
            current.Fechrealizacion = pedido.Fechrealizacion;
            current.CostTotal = pedido.CostTotal;
            current.Cantidad = pedido.Cantidad;
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
