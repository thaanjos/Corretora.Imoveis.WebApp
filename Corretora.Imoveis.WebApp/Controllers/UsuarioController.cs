using Corretora.Imoveis.Core.Authorization;
using Corretora.Imoveis.Core.Security;
using Corretora.Imoveis.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Corretora.Imoveis.WebApp.Controllers
{
    public class UsuarioController : ControllerBase
    {

        public UsuarioController(UserManager<Usuario> userManager) : base(userManager)
        {

        }


        [HttpGet]
        public async Task<IActionResult> CadastroUsuario()
        {
           

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SalvarUsuario(UsuarioViewModel usuarioViewModel)
        {

            Usuario usuario = new Usuario
            {
                Nome = usuarioViewModel.Nome,
                Celular = usuarioViewModel.Celular,
                Password = usuarioViewModel.Password,
                PasswordHash = Security.Encrypt(usuarioViewModel.Password),
                UserName = usuarioViewModel.Usuario,
                PhoneNumber = usuarioViewModel.Celular,
                Email = usuarioViewModel.Email

            };

            var result = await _userManager.CreateAsync(usuario);

            if (result.Succeeded)
            {
                MessageViewModel message = new MessageViewModel("Usuário incluído com sucesso!", "Gerencia no painel de administrador.");
                return View("SucessoMessage", message);
            }
            else
                throw new Exception("Erro ao cadastrar usuário");

        }


    }
}
