
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Models.Imovel
{
    public class Imovel
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

        public decimal ValorDe { get; set; }
        public decimal ValorAte { get; set; }

      

        public Imovel()
        {
            Imagens = new List<AnexoImovel>();

            ValorImovel = ValorDe;
            ValorImovel = ValorAte;
           
        }

        public ICollection<AnexoImovel> Imagens { get; set; }



        public Imovel(DataRow dr)
        {
           
            Logadouro = dr["logadouro"].ToString();
            Numero = dr["numero"].ToString();
            Cidade = dr["cidade"].ToString();
            UF = dr["uf"].ToString();
            Cep = dr["cep"].ToString();
            Bairro = dr["bairro"].ToString();

        }


        public void InformarAnexo(AnexoImovel anexoImovel)
        {
            if (Imagens == null)
                Imagens = new List<AnexoImovel>();

            Imagens.Add(anexoImovel);
        }


    }
}
