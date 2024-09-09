using Corretora.Imoveis.Core.Models.Contato;
using Corretora.Imoveis.Core.Services.Interfaces;
using Corretora.Imoveis.WebApp.Applications.Interfaces;
using Corretora.Imoveis.WebApp.Models;

namespace Corretora.Imoveis.WebApp.Applications
{
    public class InserirContatoApplication : IInserirContatoApplication
    {
        private readonly IInserirContatoService _inserirContatoService;

        public InserirContatoApplication(IInserirContatoService inserirContatoService)
        {
            _inserirContatoService = inserirContatoService;
        }
        public async Task<bool> InseririContato(InserirContatoViewModel inserirContatoViewModel)
        {
            var contato = new Contato
            {


                IdContato = inserirContatoViewModel.IdContato,          
                Nome = inserirContatoViewModel.Nome,
                Celular = inserirContatoViewModel.Celular,
                Email = inserirContatoViewModel.Email,
                Messagem = inserirContatoViewModel.Messagem,

            };
            if (await _inserirContatoService.InseririContato(contato))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Inserir(InserirContatoViewModel inserirContatoViewModel)
        {
            var contato = new Contato
            {


                IdContato = inserirContatoViewModel.IdContato,
                Nome = inserirContatoViewModel.Nome,
                Celular = inserirContatoViewModel.Celular,
                Email = inserirContatoViewModel.Email,
                Messagem = inserirContatoViewModel.Messagem,

            };
            if (await _inserirContatoService.InseririContato(contato))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> AtualizarContato(InserirContatoViewModel inserirContatoViewModel)
        {
            Contato contato = new Contato();
            {
                contato.IdContato = inserirContatoViewModel.IdContato;
                contato.Nome = inserirContatoViewModel.Nome;
                contato.Celular = inserirContatoViewModel.Celular;
                contato.Email = inserirContatoViewModel.Email;
                contato.Messagem = inserirContatoViewModel.Messagem;

                if (await _inserirContatoService.AtualizarContato(contato))
                {

                    return true;
                }
                return false;
            };

        }

        public async Task<bool> ExcluirContato(long id)
        {
            return await _inserirContatoService.ExcluirContato(id);
        }

        public async Task<Contato> GetById(long id)
        {
            return await _inserirContatoService.GetById(id);
        }

        public async Task<IEnumerable<Contato>> ObterTodosContatos()
        {
            return await _inserirContatoService.ObterTodosContatos();
        }

    }
}
