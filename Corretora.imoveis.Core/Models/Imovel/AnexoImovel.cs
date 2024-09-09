using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Models.Imovel
{
    public class AnexoImovel
    {
        public int IdAnexo { get; set; }
        public long IdImovel { get; set; }
        public string AnexoBase64 { get; set; }
        public string ExtensaoArquivo { get; set; }


        public AnexoImovel()
        {

        }

        public AnexoImovel(DataRow dr)
        {

        }

        public AnexoImovel(long idImovel)
        {
            IdImovel = idImovel;
        }


        public void InformarAnexoBase64(string anexo)
        {
            AnexoBase64 = anexo;
        }

        public void InformarExtensao(string extensao)
        {
            ExtensaoArquivo = extensao;
        }
    }
}
