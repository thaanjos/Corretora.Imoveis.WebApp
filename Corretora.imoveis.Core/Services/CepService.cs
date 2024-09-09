using Corretora.Imoveis.Core.Extensions;
using Corretora.Imoveis.Core.Models.Imovel;
using Corretora.Imoveis.Core.Reponses;

using Corretora.Imoveis.Core.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Services
{
    public class CepService : ICepService
    {
        public HttpClient _imovel { get; set; }
        private HttpResponseMessage _response;

        public CepService()
        {
            _imovel = new HttpClient();

            _imovel.BaseAddress = new Uri("https://viacep.com.br");
            _imovel.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<CepResponse?> GetEnderecoByCEPAsync(string cep)
        {
            try
            {
                var response = await _imovel.GetAsync(CreateRequest(EndPointCEPService.Cep, cep, "json"));

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<CepResponse>(await response.Content.ReadAsStringAsync());
                    return result;
                }

            }
            catch { }
            return null;
        }
        private string CreateRequest(EndPointCEPService endpoint, string value, string type)
        {
            string result = "";

            if (endpoint == EndPointCEPService.Cep)
            {
                result = $"{endpoint.GetEnumDescription()}/{value}/{type}";
            }
            return result;
        }
    }
}
