using Corretora.Imoveis.Core.Models.Contato;
using Corretora.Imoveis.Core.Models.Imovel;
using Corretora.Imoveis.Core.Repositorys.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Repositorys
{
    public class ContatoRepository : RepositoryBase, IContatoRepository
    {
        public ContatoRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
        public async Task<bool> InserirContato(Contato contato)
        {
            string query = "INSERT INTO contato_tb" +
                   "(IdImovel, Nome, Celular, Email, Messagem)" +
                   "VALUES (@IdImovel, @Nome, @Celular, @Email, @Messagem) returning IdContato;";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue("@IdImovel", contato.IdImovel);
            cmd.Parameters.AddWithValue("@Nome", contato.Nome);
            cmd.Parameters.AddWithValue("@Celular", contato.Celular);
            cmd.Parameters.AddWithValue("@Email", contato.Email);
            cmd.Parameters.AddWithValue("@Messagem", contato.Messagem);

            var result = await base.ExecuteScalarAsync(cmd);

            if(result != null)
            {
                contato.IdContato = long.Parse(result.ToString());
            }
            return contato.IdContato > 0;
        }

        public async Task<bool> Inseri(Contato contato)
        {
            string query = "INSERT INTO contato_tb" +
                   "( Nome, Celular, Email, Messagem)" +
                   "VALUES ( @Nome, @Celular, @Email, @Messagem) returning IdContato;";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue("@Nome", contato.Nome);
            cmd.Parameters.AddWithValue("@Celular", contato.Celular);
            cmd.Parameters.AddWithValue("@Email", contato.Email);
            cmd.Parameters.AddWithValue("@Messagem", contato.Messagem);

            var result = await base.ExecuteScalarAsync(cmd);

            if (result != null)
            {
                contato.IdContato = long.Parse(result.ToString());
            }
            return contato.IdContato > 0;
        }

        public async Task<bool> AtualizarContato(Contato contato)
        {
            string query = "UPDATE contato_tb SET =IdImovel = @IdImovel, Nome =@Nome, Celular =@Celular, Email =@Email" +
                " Messagem =@Messagem WHERE IdContato = @IdContato";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue("@IdImovel", contato.IdImovel);
            cmd.Parameters.AddWithValue("@Nome", contato.Nome);
            cmd.Parameters.AddWithValue("@Celular", contato.Celular);
            cmd.Parameters.AddWithValue("@Email", contato.Email);
            cmd.Parameters.AddWithValue("@Messagem", contato.Messagem);

            return await base.ExecuteAsync(query);

        }

        public async Task<bool> ExcluirContato(long idContato)
        {
            string query = "DELETE  FROM  contato_tb WHERE IdContato = " + idContato;

            var result = await this.ExecuteAsync(query);

            return result;
        }

        public async Task<Contato> GetById(long id)
        {
            string query = $"select * from contato_tb where IdContato = {id}";

            var result = await base.QueryAsync<Contato>(query);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Contato>> ObterTodosContatos( )
        {

            string query = "SELECT * FROM  contato_tb ";

            var result = await QueryAsync<Contato>(query);
            return result;
        }
    }
}
