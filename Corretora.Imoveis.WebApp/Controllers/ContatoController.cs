using Corretora.Imoveis.Core.Models.Contato;
using Corretora.Imoveis.Core.Models.Imovel;
using Corretora.Imoveis.WebApp.Applications;
using Corretora.Imoveis.WebApp.Applications.Interfaces;
using Corretora.Imoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Corretora.Imoveis.WebApp.Controllers
{
    [Route("[controller]")]
    public class ContatoController :Controller
    {
        private readonly IContatoApplication _contatoApplication;
        private readonly IImovelApplication _imovelApplication;

        public ContatoController(IContatoApplication contatoApplication, IImovelApplication imovelApplication)
        {
            _contatoApplication = contatoApplication;
            _imovelApplication = imovelApplication;
        }

        public async Task<IActionResult> Index()
        {
            ContatoLista result = new ContatoLista();
            result.ListaContatos = await _contatoApplication.ObterTodosContatos();
            return View(result);
        }
        [HttpGet("Inserir")]
        public async Task<IActionResult> Inseri()
        {
   
            return View();
        }

        [HttpGet("Inseri")]
        public async Task<IActionResult> InserirContato()
        {
            var obj = new ContatoViewModel();

            var listaImoveis= await _imovelApplication.ObterTodosImovel();
            obj.Imovels = listaImoveis;

            return View(obj);
        }

        [HttpGet("Inserir/{id}")]
        public async Task<IActionResult> InserirContato(int id)
        {
            var obj = new ContatoViewModel();
            obj.IdImovel = id;

            var listaImoveis = await _imovelApplication.ObterTodosImovel();
            obj.Imovels = listaImoveis;

            return View(obj);
        }


        //[HttpPost]
        //public async Task<IActionResult> SalvarConta(ContatoViewModel contatoViewModel)
        //{
        //    if (contatoViewModel.IdContato > 0)
        //    {
        //        Contato contato = new Contato();
              
        //        contato.IdImovel = contatoViewModel.IdImovel;
        //        contato.Nome = contatoViewModel.Nome;
        //        contato.Celular = contatoViewModel.Celular;
        //        contato.Email = contatoViewModel.Email;
        //        contato.Messagem = contatoViewModel.Messagem;

        //        await _contatoApplication.AtualizarContato(contatoViewModel);
        //    }
        //    else
        //    {
        //        await _contatoApplication.Inseri(contatoViewModel);
        //    }

        //    MessageViewModel message = new MessageViewModel("Contato incluído com sucesso!",
        //        "Em breve entraremos em contato, obrigado.");
        //    return View("SucessoMessage", message);
        //}


        [HttpPost]
        public async Task<IActionResult> SalvarContato(ContatoViewModel contatoViewModel)
        {
            if (contatoViewModel.IdContato > 0)
            {
                Contato contato = new Contato();

                contato.IdContato = contatoViewModel.IdContato;
                contato.IdImovel = contatoViewModel.IdImovel;
                contato.Nome = contatoViewModel.Nome;
                contato.Celular = contatoViewModel.Celular;
                contato.Email = contatoViewModel.Email;
                contato.Messagem = contatoViewModel.Messagem;

                await _contatoApplication.AtualizarContato(contatoViewModel);
            }
            if(contatoViewModel.IdImovel > 0)
            {
                await _contatoApplication.InserirContato(contatoViewModel);

            }
            else
            {
                await _contatoApplication.Inseri(contatoViewModel);
            }

            MessageViewModel message = new MessageViewModel("Contato incluído com sucesso!",
                "Em breve entraremos em contato, obrigado.");
            return View("SucessoMessage", message);
        }


        [HttpGet("ContatoAdm")]
        public async Task<IActionResult> ContatoAdm()
        {
            
            var contatoLista_ = new ContatoLista();

            contatoLista_.ListaContatos = await _contatoApplication.ObterTodosContatos();



            return View(contatoLista_);
        }

        [HttpGet("ExcluirContato/{id}")]
        public async Task<IActionResult> ExcluirContato(long id)
        {
            
            var result = await _contatoApplication.ExcluirContato(id);

            return RedirectToAction(nameof(ContatoAdm));
          
        }


        [HttpGet("VerContato/{id}")]
        public async Task<IActionResult> VerContato(long id)
        {

            var contato = await _contatoApplication.GetById(id);
            return View(contato);
        }
    }
}
