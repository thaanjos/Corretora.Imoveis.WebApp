using Corretora.Imoveis.Core.Authorization;
using Corretora.Imoveis.WebApp.Models;

namespace Corretora.Imoveis.WebApp.Applications.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<bool> IncluirUsuario(UsuarioViewModel usuarioViewModel);
        Task<bool> AtualizarUsuario(Usuario user);
        Task<bool> ExcluirUsuario(long id);

    }
}
