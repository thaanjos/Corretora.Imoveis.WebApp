namespace Corretora.Imoveis.WebApp.Models
{
    public class MessageViewModel
    {
        public string Message { get; set; }
        public string TextoInformativo { get; set; }


        public MessageViewModel()
        {

        }

        public MessageViewModel(string message)
        {
            Message = message;
        }

        public MessageViewModel(string message, string textoInformativo)
        {
            Message = message;
            TextoInformativo = textoInformativo;
        }
    }
}
