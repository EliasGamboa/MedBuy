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
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddUsuario(Usuario usuario)
        {
            Expression<Func<Usuario, bool>> exprUsuario = item => item.Nombre == usuario.Nombre;
            var productos = await _unitOfWork.UsuarioRepository.FindByCondition(exprUsuario);
        }

        public async Task DeleteUsuario(int id)
        {
            await _unitOfWork.UsuarioRepository.Delete(id);
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _unitOfWork.UsuarioRepository.GetById(id);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _unitOfWork.UsuarioRepository.GetAll();
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            await _unitOfWork.UsuarioRepository.Update(usuario);
        }
    }
}
