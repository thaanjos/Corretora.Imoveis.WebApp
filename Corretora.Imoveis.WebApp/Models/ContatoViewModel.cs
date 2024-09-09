using Corretora.Imoveis.Core.Models.Imovel;

namespace Corretora.Imoveis.WebApp.Models
{
    public class ContatoViewModel
    {
        public long IdContato { get; set; }
        public long IdImovel { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Messagem { get; set; }

        public IEnumerable<Imovel> Imovels { get; set; }

        public ContatoViewModel()
        {
            Imovels = new List<Imovel>();       
        }



        public ContatoViewModel(ContatoViewModel contatoViewModel)
        {
            IdContato = contatoViewModel.IdContato;
            IdImovel = contatoViewModel.IdImovel;
            Nome = contatoViewModel.Nome;
            Celular = contatoViewModel.Celular;
            Email = contatoViewModel.Email;
            Messagem = contatoViewModel.Messagem;

        }
    }
}
