using Corretora.Imoveis.Core.Authorization;
using Corretora.Imoveis.Core.Services.Interfaces;
using Corretora.Imoveis.WebApp.Applications.Interfaces;
using Corretora.Imoveis.WebApp.Models;

namespace Corretora.Imoveis.WebApp.Applications
{
    public class UsuarioApplication : IUsuarioApplication
    {

        private readonly IUsuarioService _usuarioServices;

        public UsuarioApplication(IUsuarioService usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }
        public async Task<bool> IncluirUsuario(UsuarioViewModel usuarioViewModel)
        {
            var obj = new Usuario()
            {
                Id_CadastroUsuario = usuarioViewModel.Id_CadastroUsuario,
                Nome = usuarioViewModel.Nome,
                NormalizedNome = usuarioViewModel.normalizedNome,
                Password = usuarioViewModel.Password,              
                Celular = usuarioViewModel.Celular,
                Email = usuarioViewModel.Email

            };
            return true;
        }

        public async Task<bool> AtualizarUsuario(Usuario user)
        {
            return await _usuarioServices.AtualizarUsuario(user);
        }

        public async Task<bool> ExcluirUsuario(long id)
        {
            return await _usuarioServices.ExcluirUsuario(id);
        }

    }
}
