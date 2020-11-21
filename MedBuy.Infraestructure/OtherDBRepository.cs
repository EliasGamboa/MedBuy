using MedBuy.Domain.Entities;
using MedBuy.Domain.Interfaces;
using MedBuy.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedBuy.Infraestructure
{
    public class OtherDBRepository : IUsuarioRepository
    {
        private readonly MedBuyContext _context;
        public OtherDBRepository(MedBuyContext _context)
        {
            this._context = _context;
        }

        public Task<Usuario> GetUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToArrayAsync();
        }
        public async Task AddUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public Task<bool> UpdateUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
