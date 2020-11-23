using MedBuy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedBuy.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Producto> ProductoRepository { get; }
        public IRepository<Usuario> UsuarioRepository { get; }
        void SaveChanges();
        Task SaveChangesAsyn();
    }
}
