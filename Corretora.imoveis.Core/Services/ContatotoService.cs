using Corretora.Imoveis.Core.Models.Contato;
using Corretora.Imoveis.Core.Repositorys.Interfaces;
using Corretora.Imoveis.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Services
{
    public class ContatotoService : IContatoService

    {
        private readonly IContatoRepository _contatoRepository;

        public ContatotoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public async Task<bool> AtualizarContato(Contato contato)
        {
          return await _contatoRepository.AtualizarContato(contato);
        }

        public async Task<bool> ExcluirContato(long id)
        {
            return await _contatoRepository.ExcluirContato(id);
        }

        public async Task<Contato> GetById(long id)
        {
            return await _contatoRepository.GetById(id);
        }

        public async Task<bool> InserirContato(Contato contato)
        {
            return await _contatoRepository.InserirContato(contato);
        }
        public async Task<bool> Inseri(Contato contato)
        {
            return await _contatoRepository.Inseri(contato);
        }


        public async Task<IEnumerable<Contato>> ObterTodosContatos( )
        {
          return await _contatoRepository.ObterTodosContatos( );
        }
    }
}
