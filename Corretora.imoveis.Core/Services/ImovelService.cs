using Corretora.Imoveis.Core.Models.Imovel;
using Corretora.Imoveis.Core.Repositorys;
using Corretora.Imoveis.Core.Repositorys.Interfaces;
using Corretora.Imoveis.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Services
{
    public class ImovelService : IImovelService
    {
        private readonly IImovelrepository _imovelRepository;

        public ImovelService(IImovelrepository imovelrepository)
        {
            _imovelRepository = imovelrepository;
        }
        public async Task<bool> InserirImovel(Imovel imovel)
        {
            return await _imovelRepository.InserirImovel(imovel);
        }
        public async Task<bool> AtualizarImovel(Imovel imovel)
        {
            return await _imovelRepository.AtualizarImovel(imovel);
        }
        public async Task<bool> IncluirAnexoImovel(AnexoImovel anexo)
        {
            return await _imovelRepository.IncluirAnexoImovel(anexo);
        }

        public async Task<IEnumerable<Imovel>> ObterTodosImovel()
        {

            var imoveis = await _imovelRepository.ObterTodosImovel();

            foreach (var imovel in imoveis)
            {
                var anexos = await ObterAnexos(imovel.IdImovel);

                imovel.Imagens = anexos.ToList();
            }

            return imoveis;
        }

        public async Task<bool> ExcluirAnexoImovel(long idImovel)
        {
            return await _imovelRepository.ExcluirAnexoImovel(idImovel);
        }

        public async Task<bool> ExcluirImovel(long idImovel)
        {
            return await _imovelRepository.ExcluirImovel(idImovel);
        }

        public async Task<Imovel> GetById(long id)
        {
            return await _imovelRepository.GetById(id);
        }

        public async Task<IEnumerable<AnexoImovel>> ObterAnexos(long idImovel)
        {
            return await _imovelRepository.ObterAnexos(idImovel);
        }

        public async Task<IEnumerable<Imovel>> GetImovel(string tipo, decimal valorDe, decimal valorAte, string cidade, string uf)
        {
            return await _imovelRepository.GetImovel(tipo, valorDe, valorAte, cidade, uf);
        }
    }
}
