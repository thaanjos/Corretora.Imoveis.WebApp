using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Authorization.Dto
{
    public class UsuarioDto
    {
        public int IdCadastroUsuario { get; set; }
        public string nome { get; set; }
        public string normalizedNome { get; set; }
        public string user_name { get; set; }
        public string senha { get; set; }      
        public string celular { get; set; }
        public string email { get; set; }



        public Usuario ToUsuario()
        {
            return new Usuario()
            {
                Id_CadastroUsuario = IdCadastroUsuario,
                Nome = nome,
                NormalizedNome = normalizedNome,
                UserName = user_name,
                Password = senha,               
                Celular = celular,
                Email = email,
            };
        }

    }
}
