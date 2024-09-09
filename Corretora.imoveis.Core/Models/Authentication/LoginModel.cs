using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Models.Authentication
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }

        public string ErrorMessage { get; set; }


        public bool PreenchidoCorretamente()
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(PasswordHash);
        }

    }
}
