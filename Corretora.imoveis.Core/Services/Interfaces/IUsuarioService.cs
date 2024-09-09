using Corretora.Imoveis.Core.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> IncluirUsuario(Usuario user);
        Task<bool> AtualizarUsuario(Usuario user);
        Task<bool> ExcluirUsuario(long id);
    }
}
