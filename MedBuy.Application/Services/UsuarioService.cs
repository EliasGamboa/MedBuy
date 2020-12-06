using MedBuy.Domain.Entities;
using MedBuy.Domain.Exceptions;
using MedBuy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedBuy.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            this._repository = repository;
        }

        public async Task AddUsuario(Usuario usuario)
        {
            await _repository.AddUsuario(usuario);
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            return await _repository.DeleteUsuario(id);
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _repository.GetUsuario(id);
        }
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _repository.GetUsuarios();
        }
        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            return await _repository.UpdateUsuario(usuario);
        }
    }
}
