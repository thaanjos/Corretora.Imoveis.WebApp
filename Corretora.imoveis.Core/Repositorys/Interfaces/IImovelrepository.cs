using Corretora.Imoveis.Core.Models.Imovel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Repositorys.Interfaces
{
    public interface IImovelrepository
    {
        Task<bool> InserirImovel(Imovel imovel);
        Task<bool> AtualizarImovel(Imovel imovel);
        Task<bool> IncluirAnexoImovel(AnexoImovel anexo);
        Task<IEnumerable<Imovel>> ObterTodosImovel( );
        Task<bool> ExcluirAnexoImovel(long idImovel);
        Task<bool> ExcluirImovel(long idImovel);
        Task<Imovel> GetById(long id);
        Task<IEnumerable<Imovel>> GetImovel(string tipo, decimal valorDe, decimal valorAte, string cidade, string uf);
        Task<IEnumerable<AnexoImovel>> ObterAnexos(long idImovel);
    }
}
