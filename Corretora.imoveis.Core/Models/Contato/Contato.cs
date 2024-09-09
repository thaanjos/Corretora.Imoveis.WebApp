using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Models.Contato
{
    public class Contato
    {
        public long IdContato { get; set; }
        public long IdImovel { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Messagem { get; set; }
    }
}
