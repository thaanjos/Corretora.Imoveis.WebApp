using Corretora.Imoveis.Core.Models.Imovel;
using Corretora.Imoveis.Core.Services.Interfaces;
using Corretora.Imoveis.WebApp.Applications.Interfaces;
using Corretora.Imoveis.WebApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace Corretora.Imoveis.WebApp.Applications
{
    public class ImovelApplication : IImovelApplication
    {
        private readonly IImovelService _imovelService;

        public ImovelApplication(IImovelService imovelService)
        {
            _imovelService = imovelService;
        }

        public async Task<bool> InserirImovel(ImovelViewModel imovelViewModel)
        {

            var imovel = new Imovel
            {

                IdImovel = imovelViewModel.IdImovel,
                Tipo = imovelViewModel.Tipo,
                Descricao = imovelViewModel.Descricao,
                DataPlubicacao = imovelViewModel.DataPlubicacao,
                ValorImovel = imovelViewModel.ValorImovel,
                ValorEstimadoDocumentacao = imovelViewModel.ValorEstimadoDocumentacao,
                AceitaFinanciamento = imovelViewModel.AceitaFinanciamento,
                Observacao = imovelViewModel.Observacao,
                Quarto = imovelViewModel.Quarto,
                Banheiro = imovelViewModel.Banheiro,
                Garagem = imovelViewModel.Garagem,
                AreaUtil = imovelViewModel.AreaUtil,
                Cep = imovelViewModel.Cep,
                Logadouro = imovelViewModel.Logadouro,
                Numero = imovelViewModel.Numero,
                Bairro = imovelViewModel.Bairro,
                Cidade = imovelViewModel.Cidade,
                UF = imovelViewModel.UF
            };
            if (await _imovelService.InserirImovel(imovel))
            {
                await this.IncluirAnexoImovel(imovelViewModel.Anexos, imovel.IdImovel);
                return true;
            }
            return false;
        }
        public async Task<bool> AtualizarImovel(ImovelViewModel imovelViewModel)
        {
            Imovel imovel = new Imovel();
            {
                imovel.IdImovel = imovelViewModel.IdImovel;
                imovel.Tipo = imovelViewModel.Tipo;
                imovel.Descricao = imovelViewModel.Descricao;
                imovel.DataPlubicacao = imovelViewModel.DataPlubicacao;
                imovel.ValorImovel = imovelViewModel.ValorImovel;
                imovel.ValorEstimadoDocumentacao = imovelViewModel.ValorEstimadoDocumentacao;
                imovel.AceitaFinanciamento = imovelViewModel.AceitaFinanciamento;
                imovel.Observacao = imovelViewModel.Observacao;
                imovel.Quarto = imovelViewModel.Quarto;
                imovel.Banheiro = imovelViewModel.Banheiro;
                imovel.Garagem = imovelViewModel.Garagem;
                imovel.AreaUtil = imovelViewModel.AreaUtil;
                imovel.Cep = imovelViewModel.Cep;
                imovel.Logadouro = imovelViewModel.Logadouro;
                imovel.Numero = imovelViewModel.Numero;
                imovel.Cidade = imovelViewModel.Cidade;
                imovel.Bairro = imovelViewModel.Bairro;
                imovel.UF = imovelViewModel.UF;


                if (await _imovelService.AtualizarImovel(imovel))
                {

                    if (imovelViewModel.Anexos?.Any() ?? false)
                    {
                        await this.ExcluirImovel(imovelViewModel.IdImovel);
                        await this.IncluirAnexoImovel(imovelViewModel.Anexos, imovelViewModel.IdImovel);
                    }

                    return true;
                }
                return false;
            };


        }
        public async Task IncluirAnexoImovel(List<IFormFile> anexos, long idImovel)
        {
            if (anexos == null)
                return;

            ICollection<AnexoImovel> anexoImovels = new List<AnexoImovel>();

            foreach (IFormFile anex in anexos)
            {
                AnexoImovel obj = new AnexoImovel(idImovel);
                var extension = anex.FileName.Substring(anex.FileName.IndexOf('.'));


                using (MemoryStream ms = new MemoryStream())
                {
                    await anex.CopyToAsync(ms);
                    obj.InformarExtensao(extension);
                    obj.InformarAnexoBase64(Convert.ToBase64String(ms.ToArray()));

                    anexoImovels.Add(obj);
                }


                await _imovelService.IncluirAnexoImovel(obj);
            }
        }
        public async Task<IEnumerable<Imovel>> ObterTodosImovel()
        {
            return await _imovelService.ObterTodosImovel();
        }
        public async Task<bool> ExcluirAnexoImovel(long id)
        {
            return await _imovelService.ExcluirAnexoImovel(id);
        }

        public async Task<bool> ExcluirImovel(long id)
        {
            await ExcluirAnexoImovel(id);
            return await _imovelService.ExcluirImovel(id);
        }

        public async Task<Imovel> GetById(long id)
        {
            var imovel = await _imovelService.GetById(id);

            if (imovel != null)
            {
                var anexos = await _imovelService.ObterAnexos(id);
                imovel.Imagens = anexos.ToList();
            }

            return imovel;
        }


        public async Task<IEnumerable<AnexoImovel>> ObterAnexos(long idImovel)
        {
            return await _imovelService.ObterAnexos(idImovel);
        }

        public async Task<IEnumerable<Imovel>> GetImovel(string tipo, decimal valorDe, decimal valorAte, string cidade, string uf)
        {
            var imoveis = await _imovelService.GetImovel(tipo, valorDe, valorAte, cidade, uf);


            if (imoveis != null)
            {
                foreach (var x in imoveis)
                {
                    var anexos = await _imovelService.ObterAnexos(x.IdImovel);
                    x.Imagens = anexos.ToList();
                }
            }

            return imoveis;
        }
    }
}
