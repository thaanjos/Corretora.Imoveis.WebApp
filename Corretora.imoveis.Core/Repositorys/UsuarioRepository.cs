using Corretora.Imoveis.Core.Authorization;
using Corretora.Imoveis.Core.Authorization.Dto;
using Corretora.Imoveis.Core.Repositorys.Interfaces;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Repositorys
{
    public class UsuarioRepository : RepositoryBase, IUsuarioRepository
    {
        public UsuarioRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<bool> IncluirUsuario(Usuario user)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("insert into cadastro_usuario_tb (Nome, normalizedLogin, Senha, " +
                " Celular, Email) returning IdCadastroUsuario;");

            cmd.Parameters.AddWithValue(@"Nome", user.Nome);
            cmd.Parameters.AddWithValue(@"normalizedLogin", user.NormalizedNome);
            cmd.Parameters.AddWithValue(@"senha", user.Password);        
            cmd.Parameters.AddWithValue(@"Celular", user.Celular);
            cmd.Parameters.AddWithValue(@"Email", user.Email);

            var result = await base.ExecuteScalarAsync(cmd);

            int id;
            if (int.TryParse(result?.ToString(), out id))
            {
                user.Id_CadastroUsuario = id;
                return true;
            }
            else
                return false;
        }

        public async Task<bool> AtualizarUsuario(Usuario user)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("update cadastro_usuario_tb set Nome = @Nome, normalizedLogin = @normalizedLogin" +
                " Senha = @Senha, Celular = @Celular" +
                " Email = @Email where IdUsuario = @IdCadastroUsuario");

            cmd.Parameters.AddWithValue(@"Nome", user.Nome);
            cmd.Parameters.AddWithValue(@"normalizedLogin", user.NormalizedNome);
            cmd.Parameters.AddWithValue(@"Senha", user.Password);       
            cmd.Parameters.AddWithValue(@"Celular", user.Celular);
            cmd.Parameters.AddWithValue(@"Email", user.Email);
            cmd.Parameters.AddWithValue(@"IdCadastroUsuario", user.Id_CadastroUsuario);


            var result = await base.ExecuteCommand(cmd);

            return result;
        }

        public async Task<bool> ExcluirUsuario(long id)
        {
            string query = $"delete from cadastro_usuario_tb where IdCadastroUsuario = {id}";

            if (await base.ExecuteAsync(query))
                return await base.ExecuteAsync($"delete from cadastro_usuario_tb where IdCadastroUsuario = {id}");

            return false;
        }

        public Task<IEnumerable<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAllAdministradores()
        {
            throw new NotImplementedException();
        }


       

        public async Task<Usuario?> ObterPorNome(string userNameNormalized)
        {
            string query = $"select * from cadastro_usuario_tb where UPPER(user_name) LIKE '{userNameNormalized.ToUpper()}'";
            var usuarioDto = await base._dbConnection.QueryAsync<UsuarioDto>(query);

            return usuarioDto.FirstOrDefault()?.ToUsuario() ?? null;
        }

        public async Task<Usuario> GetById(long idUsuario)
        {
            string query = $"select * from cadastro_usuario_tb where IdCadastroUsuario = {idUsuario}";
            var usuarioDto = await base._dbConnection.QueryAsync<UsuarioDto>(query);

            return usuarioDto.FirstOrDefault()?.ToUsuario() ?? null;
        }

        async Task<string> IUsuarioRepository.GetMessage()
        {
            return Message;
        }
    }
}
