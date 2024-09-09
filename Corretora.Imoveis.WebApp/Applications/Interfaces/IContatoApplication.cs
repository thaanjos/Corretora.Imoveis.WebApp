using Corretora.Imoveis.Core.Models.Contato;
using Corretora.Imoveis.WebApp.Models;

namespace Corretora.Imoveis.WebApp.Applications.Interfaces
{
    public interface IContatoApplication
    {
        Task<bool> InserirContato(ContatoViewModel contatoViewModel);
        Task<bool> Inseri(ContatoViewModel contatoViewModel);
        Task<bool> AtualizarContato(ContatoViewModel contatoViewModel);
        Task<bool> ExcluirContato(long id);
        Task<IEnumerable<Contato>> ObterTodosContatos( );
        Task<Contato> GetById(long id);
    }
}
