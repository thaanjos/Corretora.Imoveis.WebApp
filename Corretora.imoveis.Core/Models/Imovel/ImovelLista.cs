using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Models.Imovel
{
    public class ImovelLista
    {
        public IEnumerable<Imovel> ListaImoveis { get; set; }

        public decimal ValorDe { get; set; }
        public decimal ValorAte { get; set; }

        public string Tipo { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

    }
}
