using Corretora.Imoveis.Core.Models.Contato;
using Corretora.Imoveis.Core.Models.Imovel;
using Corretora.Imoveis.Core.Services;
using Corretora.Imoveis.Core.Services.Interfaces;
using Corretora.Imoveis.WebApp.Applications.Interfaces;
using Corretora.Imoveis.WebApp.Models;

namespace Corretora.Imoveis.WebApp.Applications
{
    public class ContatoApplication : IContatoApplication
    {
        private readonly IContatoService _contatoService;

        public ContatoApplication(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public async Task<bool> InserirContato(ContatoViewModel contatoViewModel)
        {
            var contato = new Contato
            {


                IdContato = contatoViewModel.IdContato,
                IdImovel = contatoViewModel.IdImovel,
                Nome = contatoViewModel.Nome,
                Celular = contatoViewModel.Celular,
                Email = contatoViewModel.Email,
                Messagem = contatoViewModel.Messagem,

            };
            if (await _contatoService.InserirContato(contato))
            {         
                return true;
            }
            return false;
        }

        public async Task<bool> Inseri(ContatoViewModel contatoViewModel)
        {
            var contato = new Contato
            {


                IdContato = contatoViewModel.IdContato,
                Nome = contatoViewModel.Nome,
                Celular = contatoViewModel.Celular,
                Email = contatoViewModel.Email,
                Messagem = contatoViewModel.Messagem,

            };
            if (await _contatoService.Inseri(contato))
            {
                return true;
            }
            return false;
        }
        public async Task<bool> AtualizarContato(ContatoViewModel contatoViewModel)
        {
            Contato contato = new Contato();
            {
                contato.IdContato = contatoViewModel.IdContato;
                contato.IdImovel = contatoViewModel.IdImovel;
                contato.Nome = contatoViewModel.Nome;
                contato.Celular = contatoViewModel.Celular;
                contato.Email = contatoViewModel.Email;
                contato.Messagem = contatoViewModel.Messagem;

                if (await _contatoService.AtualizarContato(contato))
                {

                    return true;
                }
                return false;
            };

        }

        public async Task<bool> ExcluirContato(long id)
        {
            return await _contatoService.ExcluirContato(id);
        }

        public async Task<Contato> GetById(long id)
        {
            return await _contatoService.GetById(id);
        }

        public async Task<IEnumerable<Contato>> ObterTodosContatos( )
        {
            return await _contatoService.ObterTodosContatos();
        }
    }
}
