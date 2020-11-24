using MedBuy.Domain.Entities;
using MedBuy.Domain.Interfaces;
using MedBuy.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedBuy.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MedBuyContext _context;
        public UsuarioRepository(MedBuyContext _context)
        {
            this._context = _context;
        }
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToArrayAsync();
        }
        public async Task<Usuario> GetUsuario(int id)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(usuario => usuario.Id == id)
                ?? new Usuario();
        }
        public async Task AddUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteUsuario(int id)
        {
            var current = await GetUsuario(id);
            _context.Usuarios.Remove(current);
            var rowsDelete = await _context.SaveChangesAsync();
            return rowsDelete > 0;
        }
        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            var current = await GetUsuario(usuario.Id);
            current.Id = usuario.Id;
            current.Nombre = usuario.Nombre;
            current.Apellido = usuario.Apellido;
            current.Telefono = usuario.Telefono;
            var rowsUpdate = await _context.SaveChangesAsync();
            return rowsUpdate > 0;
        }
    }
}
