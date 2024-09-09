using Corretora.Imoveis.Core.Models.Imovel;
using Corretora.Imoveis.Core.Services;
using Corretora.Imoveis.Core.Services.Interfaces;
using Corretora.Imoveis.WebApp.Applications.Interfaces;
using Corretora.Imoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Runtime.ConstrainedExecution;

namespace Corretora.Imoveis.WebApp.Controllers
{
    public class ImovelController : Controller
    {
        private readonly IImovelApplication _imovelApplication;
        private readonly ICepService _cepService;
        public ImovelController(IImovelApplication imovelApplication, ICepService cepService)
        {
            _imovelApplication = imovelApplication;
            _cepService = cepService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(ImovelLista imovelLista)
        {
            if (imovelLista?.ListaImoveis == null)
            {
                ImovelLista result = new ImovelLista();
                result.ListaImoveis = await _imovelApplication.ObterTodosImovel();
                return View(result);
            }
            else
            {
                return View(imovelLista);
            }
        }
        [HttpGet]
        public async Task<IActionResult> IncluirImovel()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> NovoImovel()
        {
            ImovelViewModel imovelViewModel = new ImovelViewModel();


            return View("IncluirImovel", imovelViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> VerImovel([FromBody] Imovel imovel)
        {


            return View(imovel);
        }

        [HttpGet]
        public async Task<IActionResult> EditarImovel(long id)
        {
            var result = await _imovelApplication.GetById(id);

            var imovelViewModel = new ImovelViewModel();

            imovelViewModel.IdImovel = result.IdImovel;
            imovelViewModel.Tipo = result.Tipo;
            imovelViewModel.Descricao = result.Descricao;
            imovelViewModel.DataPlubicacao = result.DataPlubicacao;
            imovelViewModel.ValorImovel = result.ValorImovel;
            imovelViewModel.ValorEstimadoDocumentacao = result.ValorEstimadoDocumentacao;
            imovelViewModel.AceitaFinanciamento = result.AceitaFinanciamento;
            imovelViewModel.Observacao = result.Observacao;
            imovelViewModel.Quarto = result.Quarto;
            imovelViewModel.Banheiro = result.Banheiro;
            imovelViewModel.Garagem = result.Garagem;
            imovelViewModel.AreaUtil = result.AreaUtil;
            imovelViewModel.Cep = result.Cep;
            imovelViewModel.Logadouro = result.Logadouro;
            imovelViewModel.Numero = result.Numero;
            imovelViewModel.Bairro = result.Bairro;
            imovelViewModel.Cidade = result.Cidade;
            imovelViewModel.UF = result.UF;

            return View("IncluirImovel", imovelViewModel);

        }



        [HttpPost]
        public async Task<IActionResult> FiltrarImoveis(ImovelLista model)
        {

            decimal valorDe = model.ValorDe;
            decimal valorAte = model.ValorAte;
            string tipo = model.Tipo; /*string.Empty;*/
            string cidade = model.Cidade;
            string uf = model.UF;


            var result = new ImovelLista();
            result.ListaImoveis = await _imovelApplication.GetImovel(tipo, valorDe, valorAte, cidade, uf);

            return View(nameof(Index), result);
        }




        [HttpPost]
        public async Task<IActionResult> SalvarImovel(ImovelViewModel imovelViewModel)
        {
            if (imovelViewModel.IdImovel > 0)
            {
                Imovel imovel = new Imovel();

                imovel.IdImovel = imovelViewModel.IdImovel;
                imovel.Tipo = imovelViewModel.Tipo;
                imovel.Descricao = imovelViewModel.Descricao;
                imovel.DataPlubicacao = imovelViewModel.DataPlubicacao;
                imovel.ValorImovel = imovelViewModel.ValorImovel;
                imovel.ValorEstimadoDocumentacao = imovelViewModel.ValorEstimadoDocumentacao;
                imovel.AceitaFinanciamento = imovelViewModel.AceitaFinanciamento;
                imovel.Observacao = imovelViewModel.Observacao;
                imovel.Quarto = imovelViewModel.Quarto;
                imovel.Banheiro = imovelViewModel.Banheiro;
                imovel.Garagem = imovelViewModel.Garagem;
                imovel.AreaUtil = imovelViewModel.AreaUtil;
                imovel.Cep = imovelViewModel.Cep;
                imovel.Logadouro = imovelViewModel.Logadouro;
                imovel.Numero = imovelViewModel.Numero;
                imovel.Bairro = imovelViewModel.Bairro;
                imovel.Cidade = imovelViewModel.Cidade;
                imovel.UF = imovelViewModel.UF;

                await _imovelApplication.AtualizarImovel(imovelViewModel);
            }
            else
            {

                await _imovelApplication.InserirImovel(imovelViewModel);
            }

            MessageViewModel message = new MessageViewModel("Imovel adicionada com sucesso!");

            return View("SucessoMessage", message);

        }



        [HttpGet]
        public async Task<IActionResult> ImovelAdm()
        {


            var imovelLista_ = new ImovelLista();


            imovelLista_.ListaImoveis = await _imovelApplication.ObterTodosImovel();



            return View(imovelLista_);
        }

        [HttpGet]
        public async Task<IActionResult> ExcluirAnexoImovel(long id)
        {

            var result = await _imovelApplication.ExcluirAnexoImovel(id);

            return RedirectToAction(nameof(Imovel));
        }

        [HttpGet]
        public async Task<IActionResult> ExcluirImovel(long id)
        {

            var result = await _imovelApplication.ExcluirImovel(id);

            return RedirectToAction(nameof(ImovelAdm));
        }
        [HttpGet]
        public async Task<JsonResult> ObterDadosCEP(string CEP)
        {
            var result = await _cepService.GetEnderecoByCEPAsync(CEP);
            return Json(result);
        }

        [HttpGet("format")]
        public ActionResult<string> GetFormattedMoney([FromQuery] decimal amount)
        {
            // Formatar o valor monetário de acordo com a cultura atual
            var formattedAmount = string.Format(CultureInfo.CurrentCulture, "{0:C2}", amount);
            return Ok(formattedAmount);
        }
    }
}
