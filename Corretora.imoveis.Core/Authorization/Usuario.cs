using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Authorization
{
    public class Usuario : IdentityUser<long>
    {
        public long Id_CadastroUsuario { get; set; }
        public string Nome { get; set; }
        public string NormalizedNome { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Celular { get; set; }
        public string Email { get; set; }



        public bool CheckPassword(string passwordHash)
        {
            return Password.Equals(passwordHash);
        }

    }
}

