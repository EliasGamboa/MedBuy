using MedBuy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedBuy.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetUsuarios();

        Task<Usuario> GetUsuario(int id);

        Task AddUsuario(Usuario usuario);

        Task UpdateUsuario(Usuario usuario);

        Task DeleteUsuario(int id);
    }
}
