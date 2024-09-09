using Corretora.Imoveis.Core.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Repositorys.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> IncluirUsuario(Usuario user);
        Task<bool> AtualizarUsuario(Usuario user);
        Task<bool> ExcluirUsuario(long id);
        Task<Usuario?> ObterPorNome(string userNameNormalized);
        Task<Usuario> GetById(long idUsuario);
        Task<string> GetMessage();

        Task<IEnumerable<Usuario>> GetAll();
        Task<IEnumerable<Usuario>> GetAllAdministradores();

    }
}
