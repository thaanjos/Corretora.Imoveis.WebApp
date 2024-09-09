using Corretora.Imoveis.Core.Models.Contato;
using Corretora.Imoveis.WebApp.Applications;
using Corretora.Imoveis.WebApp.Applications.Interfaces;
using Corretora.Imoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Corretora.Imoveis.WebApp.Controllers
{

    [Route("[controller]")]
    public class InserirContato : Controller
    {
        private readonly IInserirContatoApplication _inserirContatoApplication;
        private readonly IImovelApplication _imovelApplication;


        public InserirContato(IInserirContatoApplication IInserirContatoApplication, IImovelApplication imovelApplication)
        {
            _inserirContatoApplication = IInserirContatoApplication;
            _imovelApplication = imovelApplication;

        }
        public async Task<IActionResult> Index()
        {
            ContatoLista result = new ContatoLista();
            result.ListaContatos = await _inserirContatoApplication.ObterTodosContatos();
            return View(result);
        }

        [HttpGet("Inserir")]
        public async Task<IActionResult> Inseri()
        {
            var obj = new InserirContatoViewModel();

            var listaImoveis = await _imovelApplication.ObterTodosImovel();
            obj.Imovels = listaImoveis;

            return View(obj);
        }



        [HttpPost]
        public async Task<IActionResult> Salvar(InserirContatoViewModel inserirContatoViewModel)
        {
            if (inserirContatoViewModel.IdContato > 0)
            {
                Contato contato = new Contato();

                contato.IdContato = inserirContatoViewModel.IdContato;
                contato.Nome = inserirContatoViewModel.Nome;
                contato.Celular = inserirContatoViewModel.Celular;
                contato.Email = inserirContatoViewModel.Email;
                contato.Messagem = inserirContatoViewModel.Messagem;

                await _inserirContatoApplication.AtualizarContato(inserirContatoViewModel);
            }
            else
            {
                await _inserirContatoApplication.Inserir(inserirContatoViewModel);
            }

            MessageViewModel message = new MessageViewModel("Contato incluído com sucesso!",
                "Em breve entraremos em contato, obrigado.");
            return View("SucessoMessage", message);
        }

        [HttpGet("ContatoAdm")]
        public async Task<IActionResult> ContatoAdm()
        {

            var contatoLista_ = new ContatoLista();

            contatoLista_.ListaContatos = await _inserirContatoApplication.ObterTodosContatos();



            return View(contatoLista_);
        }

        [HttpGet("ExcluirContato/{id}")]
        public async Task<IActionResult> ExcluirContato(long id)
        {

            var result = await _inserirContatoApplication.ExcluirContato(id);

            return RedirectToAction(nameof(ContatoAdm));

        }


        [HttpGet("VerContato/{id}")]
        public async Task<IActionResult> VerContato(long id)
        {

            var contato = await _inserirContatoApplication.GetById(id);
            return View(contato);
        }
    }
}
