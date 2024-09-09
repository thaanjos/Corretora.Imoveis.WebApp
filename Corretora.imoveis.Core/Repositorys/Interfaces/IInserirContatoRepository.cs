using Corretora.Imoveis.Core.Models.Contato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Repositorys.Interfaces
{
    public interface IInserirContatoRepository
    {
        Task<bool> InseririContato(Contato contato);
        Task<bool> Inserir(Contato contato);
        Task<bool> AtualizarContato(Contato contato);
        Task<bool> ExcluirContato(long idContato);
        Task<IEnumerable<Contato>> ObterTodosContatos();
        Task<Contato> GetById(long id);
    }
}
