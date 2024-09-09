using Corretora.Imoveis.Core.Authorization;
using Corretora.Imoveis.Core.Repositorys.Interfaces;
using Corretora.Imoveis.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Services
{
    public class UsuarioService :IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> AtualizarUsuario(Usuario user)
        {
            return await _usuarioRepository.AtualizarUsuario(user);
        }

        public async Task<bool> ExcluirUsuario(long id)
        {
            return await _usuarioRepository.ExcluirUsuario(id);
        }

        public async Task<bool> IncluirUsuario(Usuario user)
        {
            return await _usuarioRepository.IncluirUsuario(user);
        }

    }
}
