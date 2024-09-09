using Corretora.Imoveis.Core.Models.Imovel;
using Corretora.Imoveis.WebApp.Models;

namespace Corretora.Imoveis.WebApp.Applications.Interfaces
{
    public interface IImovelApplication
    {
        Task<bool> InserirImovel(ImovelViewModel imovelViewModel);
        Task<bool> AtualizarImovel(ImovelViewModel imovelViewModel);
        Task<bool> ExcluirAnexoImovel(long id);
        Task<bool> ExcluirImovel(long id);
        Task IncluirAnexoImovel(List<IFormFile> anexos, long idImovel);
        Task<IEnumerable<Imovel>> ObterTodosImovel();
        Task<Imovel> GetById(long id);
        Task<IEnumerable<Imovel>> GetImovel(string tipo, decimal valorDe, decimal valorAte, string cidade, string uf);
        Task<IEnumerable<AnexoImovel>> ObterAnexos(long idImovel);
       
    }
}
