using Corretora.Imoveis.Core.Models.Imovel;
using Corretora.Imoveis.Core.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Services.Interfaces
{
    public interface ICepService
    {
        Task<CepResponse?> GetEnderecoByCEPAsync(string cep);
    }
}
