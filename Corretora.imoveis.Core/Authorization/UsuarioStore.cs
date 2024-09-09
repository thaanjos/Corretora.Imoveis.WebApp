using Corretora.Imoveis.Core.Repositorys.Interfaces;
using Corretora.Imoveis.Core.Services.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Authorization
{
    public class UsuarioStore : IUserStore<Usuario>, IUserPasswordStore<Usuario>, IUserClaimStore<Usuario>
    {
        protected readonly IDbConnection _connection;
        protected readonly IUsuarioRepository _usuarioRepository;

        public UsuarioStore(IDbConnection connection, IUsuarioRepository usuarioRepository)
        {
            _connection = connection;
            _usuarioRepository = usuarioRepository;
        }


        public async Task AddClaimsAsync(Usuario user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {

        }

        public async Task<IdentityResult> CreateAsync(Usuario user, CancellationToken cancellationToken)
        {
            var inserted = await _connection.ExecuteAsync("insert into cadastro_usuario_tb (Nome, normalizedNome, user_name, Senha,  Celular, Email)" +
                "values (@Nome, @normalizedNome, @user_name, @Senha, @Celular, @Email)",
                new
                {
                    nome = user.Nome,
                    normalizedNome = user.NormalizedNome,
                    user_name = user.UserName,
                    senha = user.PasswordHash,
                    celular = user.Celular,
                    email = user?.Email ?? ""

                }); 

            if (inserted > 0)
                return IdentityResult.Success;
            else
                return IdentityResult.Failed(new IdentityError[] { new IdentityError() { Description = "Erro ao inserir o usuário." } });

        }

        public async Task<IdentityResult> DeleteAsync(Usuario user, CancellationToken cancellationToken)
        {
            var identityResult = new IdentityResult();


            var success = await _usuarioRepository.ExcluirUsuario(user.Id_CadastroUsuario);

            if (!success)
                identityResult.Errors.ToList().Add(new IdentityError { Code = "500", Description = "Erro ao excluir usuário" });


            return identityResult;

        }

        public void Dispose()
        {

        }

        public async Task<Usuario?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.GetById(long.Parse(userId));
        }

        public async Task<Usuario?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.ObterPorNome(normalizedUserName);
        }

        public async Task<IList<Claim>> GetClaimsAsync(Usuario user, CancellationToken cancellationToken)
        {
            return new List<Claim>();
        }

        public async Task<string?> GetNormalizedUserNameAsync(Usuario user, CancellationToken cancellationToken)
        {
            return user.NormalizedUserName;
        }

        public async Task<string?> GetPasswordHashAsync(Usuario user, CancellationToken cancellationToken)
        {
            return user.PasswordHash;
        }

        public async Task<string> GetUserIdAsync(Usuario user, CancellationToken cancellationToken)
        {
            return user.Id_CadastroUsuario.ToString();
        }

        public async Task<string?> GetUserNameAsync(Usuario user, CancellationToken cancellationToken)
        {
            return user.UserName;
        }

        public async Task<IList<Usuario>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            return new List<Usuario>();
        }

        public async Task<bool> HasPasswordAsync(Usuario user, CancellationToken cancellationToken)
        {
            return !string.IsNullOrEmpty(user.Password);
        }

        public async Task RemoveClaimsAsync(Usuario user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {

        }

        public async Task ReplaceClaimAsync(Usuario user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {

        }

        public async Task SetNormalizedUserNameAsync(Usuario user, string? normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedNome = normalizedName;
        }

        public async Task SetPasswordHashAsync(Usuario user, string? passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
        }

        public async Task SetUserNameAsync(Usuario user, string? userName, CancellationToken cancellationToken)
        {
            user.UserName = user.UserName ?? string.Empty;
        }

        public async Task<IdentityResult> UpdateAsync(Usuario user, CancellationToken cancellationToken)
        {
            var identityResult = new IdentityResult();

            var result = await _usuarioRepository.AtualizarUsuario(user);
            if (result)
                return identityResult;

            else
            {
                identityResult.Errors.ToList().Add(new IdentityError { Code = "500" });
                return identityResult;
            }
        }
    }
}
