using MedBuy.Domain.Entities;
using MedBuy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedBuy.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;

        public PedidoService(IPedidoRepository repository)
        {
            this._repository = repository;
        }
        public async Task<IEnumerable<Pedido>> GetPedidos()
        {
            return await _repository.GetPedidos();
        }
        public async Task<Pedido> GetPedido(int id)
        {
            return await _repository.GetPedido(id);
        }

        public async Task AddPedido(Pedido pedido)
        {
            await _repository.AddPedido(pedido);
        }

        public async Task<bool> UpdatePedido(Pedido pedido)
        {
            return await _repository.UpdatePedido(pedido);
        }

        public async Task<bool> DeletePedido(int id)
        {
            return await _repository.DeletePedido(id);
        }
    }
}
