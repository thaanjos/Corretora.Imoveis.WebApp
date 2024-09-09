using Corretora.Imoveis.Core.Authorization;
using Corretora.Imoveis.Core.Models.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Corretora.Imoveis.Core.Security;

namespace Corretora.Imoveis.WebApp.Controllers
{
    public class ControllerBase : Controller
    
    {

        protected readonly UserManager<Usuario> _userManager;

        public ControllerBase(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        protected async Task<Usuario?> Autenticar(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);


            if (user != null)
            {
                if (user.CheckPassword(Security.Encrypt(model.Password)))
                {
                    var identity = new ClaimsIdentity("cookies");

                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id_CadastroUsuario.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, model.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Hash, user.Password));
                    identity.AddClaims(await _userManager.GetClaimsAsync(user));

                    var userClaim = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync("cookies", userClaim);

                    return user;
                }
            }

            return null;
        }


        protected async Task<bool> Deslogar()
        {
            if (User != null)
            {
                await HttpContext.SignOutAsync("cookies");
            }

            return true;
        }


        protected long GetIdUsuarioLogado()
        {
            var claimUser = HttpContext?.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier);

            if (claimUser != null)
            {
                return long.Parse(claimUser.Value.ToString());
            }
            else
                return -1;
        }



        protected string GetUserNameLogado()
        {
            var claimUser = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name);

            if (claimUser != null)
            {
                return claimUser.Value.ToString();
            }
            else
                return "";
        }
      

    }
}
