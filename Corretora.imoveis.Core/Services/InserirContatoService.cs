using Corretora.Imoveis.Core.Models.Contato;
using Corretora.Imoveis.Core.Repositorys;
using Corretora.Imoveis.Core.Repositorys.Interfaces;
using Corretora.Imoveis.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Services
{
    public class InserirContatoService : IInserirContatoService
    {
     private readonly IInserirContatoRepository _inserirContatoRepository;

        public InserirContatoService(IInserirContatoRepository inserirContatoRepository)
        {
            _inserirContatoRepository = inserirContatoRepository;
        }
        public async Task<bool> AtualizarContato(Contato contato)
        {
            return await _inserirContatoRepository.AtualizarContato(contato);
        }

        public async Task<bool> ExcluirContato(long id)
        {
            return await _inserirContatoRepository.ExcluirContato(id);
        }

        public async Task<Contato> GetById(long id)
        {
            return await _inserirContatoRepository.GetById(id);
        }

        public async Task<bool> InseririContato(Contato contato)
        {
            return await _inserirContatoRepository.InseririContato(contato);
        }
        public async Task<bool> Inserir(Contato contato)
        {
            return await _inserirContatoRepository.InseririContato(contato);
        }

        public async Task<IEnumerable<Contato>> ObterTodosContatos()
        {
            return await _inserirContatoRepository.ObterTodosContatos();
        }

    }
}
