using Corretora.Imoveis.Core.Models.Contato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Services.Interfaces
{
    public interface IContatoService
    {
        Task<bool> InserirContato(Contato contato);
        Task<bool> Inseri(Contato contato);
        Task<bool> AtualizarContato(Contato contato);
        Task<bool> ExcluirContato(long id);
        Task<IEnumerable<Contato>> ObterTodosContatos( );
        Task<Contato> GetById(long id);
    }
}
