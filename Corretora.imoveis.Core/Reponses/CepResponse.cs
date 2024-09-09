using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Reponses
{
    public class CepResponse
    {
        public CepResponse()
        {

        }

        [JsonProperty("cep")]
        public string CEP { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }   

        [JsonProperty("localidade")]
        public string Localidade { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("uf")]
        public string UF { get; set; }

        [JsonProperty("ibge")]
        public string IBGE { get; set; }

        [JsonProperty("ddd")]
        public string DDD { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }
    }
}
