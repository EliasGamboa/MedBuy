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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MedBuyContext _context;
        public UsuarioRepository(MedBuyContext context)
        {
            this._context = context;
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

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(Usuario => Usuario.Id == id)
            ?? new Usuario();
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            var current = await GetUsuario(usuario.Id);
            current.Usuario1 = usuario.Usuario1;
            current.Nombre = usuario.Nombre;
            current.Apellido = usuario.Apellido;
            current.Telefono = usuario.Telefono;
            current.Contraseña = usuario.Contraseña;
            var rowsUpdate = await _context.SaveChangesAsync();
            return rowsUpdate > 0;
        }
    }
}
