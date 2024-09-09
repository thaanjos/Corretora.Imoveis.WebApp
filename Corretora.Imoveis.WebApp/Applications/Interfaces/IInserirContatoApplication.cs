using Corretora.Imoveis.Core.Models.Contato;
using Corretora.Imoveis.WebApp.Models;

namespace Corretora.Imoveis.WebApp.Applications.Interfaces
{
    public interface IInserirContatoApplication
    {
        Task<bool> InseririContato(InserirContatoViewModel inserirContatoViewModel);
        Task<bool> Inserir(InserirContatoViewModel inserirContatoViewModel);
        Task<bool> AtualizarContato(InserirContatoViewModel inserirContatoViewModel);
        Task<bool> ExcluirContato(long id);
        Task<IEnumerable<Contato>> ObterTodosContatos();
        Task<Contato> GetById(long id);
    }
}
