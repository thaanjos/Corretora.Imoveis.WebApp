using System.ComponentModel.DataAnnotations;

namespace Corretora.Imoveis.WebApp.Models
{
    public class UsuarioViewModel
    {

        public long Id_CadastroUsuario { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string normalizedNome { get { return Nome.ToUpper(); } }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Celular { get; set; }
        public string Email { get; set; }

        public List<IFormFile> Anexos { get; set; }

        public UsuarioViewModel()
        {
            Anexos = new List<IFormFile>();
        }

    }  
}
