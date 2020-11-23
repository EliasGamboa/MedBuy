using MedBuy.Domain.Entities;
using MedBuy.Domain.Interfaces;
using MedBuy.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedBuy.Infraestructure.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly MedBuyContext _context;
        public UnitOfWork(MedBuyContext context)
        {
            _context = context;
        }

        private readonly IRepository<Producto> _productoRepository;
        private readonly IRepository<Usuario> _usuarioRepository;

        public IRepository<Producto> ProductoRepository => _productoRepository ?? new
            SQLRepository<Producto>(_context);

        public IRepository<Usuario> UsuarioRepository => _usuarioRepository ?? new
            SQLRepository<Usuario>(_context);

        public void Dispose()
        {
            if (_context == null)
                _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsyn()
        {
           await _context.SaveChangesAsync();
        }
    }
}
