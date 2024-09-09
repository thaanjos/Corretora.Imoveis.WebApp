using Corretora.Imoveis.Core.Models.Imovel;

namespace Corretora.Imoveis.WebApp.Models
{
    public class InserirContatoViewModel
    {
        public long IdContato { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Messagem { get; set; }

        public IEnumerable<Imovel> Imovels { get; set; }

        public InserirContatoViewModel()
        {
            Imovels = new List<Imovel>();
        }



        public InserirContatoViewModel(InserirContatoViewModel inserirContatoViewModel)
        {
            IdContato = inserirContatoViewModel.IdContato;
            Nome = inserirContatoViewModel.Nome;
            Celular = inserirContatoViewModel.Celular;
            Email = inserirContatoViewModel.Email;
            Messagem = inserirContatoViewModel.Messagem;

        }
    }
}
