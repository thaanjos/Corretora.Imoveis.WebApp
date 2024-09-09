using Corretora.Imoveis.Core.Models.Imovel;
using System.ComponentModel.DataAnnotations;

namespace Corretora.Imoveis.WebApp.Models
{
    public class ImovelViewModel
    {
        public long IdImovel { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPlubicacao { get; set; }
        [DataType(DataType.Currency)]
        public decimal ValorImovel { get; set; }
        [DataType(DataType.Currency)]
        public decimal ValorEstimadoDocumentacao { get; set; }
        public string AceitaFinanciamento { get; set; }
        public string Observacao { get; set; }
        public string Quarto { get; set; }
        public string Banheiro { get; set; }
        public string Garagem { get; set; }
        public string AreaUtil { get; set; }
        public string Cep { get; set; }
        public string Logadouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public Imovel Imovel { get; set; }

        public List<IFormFile> Anexos { get; set; }
        public ICollection<AnexoImovel> Imagens { get; set; }



        

        public ImovelViewModel()
        {
            Anexos = new List<IFormFile>();
        }

        public ImovelViewModel(Imovel imovel)
        {
            IdImovel = imovel.IdImovel;
            Tipo = imovel.Tipo;
            Descricao = imovel.Descricao;
            DataPlubicacao = imovel.DataPlubicacao;
            ValorImovel = imovel.ValorImovel;
            ValorEstimadoDocumentacao = imovel.ValorEstimadoDocumentacao;
            AceitaFinanciamento = imovel.AceitaFinanciamento;
            Observacao = imovel.Observacao;
            Quarto = imovel.Quarto;
            Banheiro = imovel.Banheiro;
            Garagem = imovel.Garagem;
            AreaUtil = imovel.AreaUtil;
            Cep = imovel.Cep;
            Logadouro = imovel.Logadouro;
            Numero = imovel.Numero;
            Bairro = imovel.Bairro;
            Cidade = imovel.Cidade;
            UF = imovel.UF;

        }
    }
}
