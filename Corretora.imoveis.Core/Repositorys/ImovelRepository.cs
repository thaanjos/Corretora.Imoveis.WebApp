using Corretora.Imoveis.Core.Models.Imovel;
using Corretora.Imoveis.Core.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Corretora.Imoveis.Core.Repositorys
{
    public class ImovelRepository : RepositoryBase, IImovelrepository
    {
        public ImovelRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<bool> InserirImovel(Imovel imovel)
        {
            string query = "insert into imoveis_tb" +
                "(Tipo, Descricao, DataPublicacao, ValorImovel, " +
                "ValorEstimadoDocumentacao, AceitaFinanciamento, Observacao, Quarto, Banheiro, Garagem, AreaUtil,  Logadouro, Cep, Numero, Bairro, Cidade, UF)" +
                "values (@Tipo, @Descricao, @DataPublicacao, @ValorImovel, @ValorEstimadoDocumentacao, @AceitaFinanciamento," +
                "@Observacao, @Quarto, @Banheiro, @Garagem, @AreaUtil , @Logadouro, @Cep, @Numero, @Bairro, @Cidade, @UF) returning IdImovel";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue("@Tipo", imovel.Tipo);
            cmd.Parameters.AddWithValue("@Descricao", imovel.Descricao);
            cmd.Parameters.AddWithValue("@DataPublicacao", imovel.DataPlubicacao);
            cmd.Parameters.AddWithValue("@ValorImovel", imovel.ValorImovel);
            cmd.Parameters.AddWithValue("@ValorEstimadoDocumentacao", imovel.ValorEstimadoDocumentacao);
            cmd.Parameters.AddWithValue("@AceitaFinanciamento", imovel.AceitaFinanciamento);
            cmd.Parameters.AddWithValue("@Observacao", imovel.Observacao);
            cmd.Parameters.AddWithValue("@Quarto", imovel.Quarto);
            cmd.Parameters.AddWithValue("@Banheiro", imovel.Banheiro);
            cmd.Parameters.AddWithValue("@Garagem", imovel.Garagem);
            cmd.Parameters.AddWithValue("@AreaUtil", imovel.AreaUtil);      
            cmd.Parameters.AddWithValue("@Logadouro", imovel.Logadouro);
            cmd.Parameters.AddWithValue("@Cep", imovel.Cep);
            cmd.Parameters.AddWithValue("@Bairro", imovel.Bairro);
            cmd.Parameters.AddWithValue("@Numero", imovel.Numero);
            cmd.Parameters.AddWithValue("@Cidade", imovel.Cidade);
            cmd.Parameters.AddWithValue("@UF", imovel.UF);

            var result = await base.ExecuteScalarAsync(cmd);

            if (result != null)
            {
                imovel.IdImovel = long.Parse(result.ToString());
            }

            return imovel.IdImovel > 0;
        }
        public async Task<bool> AtualizarImovel(Imovel imovel)
        {
            string query = "update  imoveis_tb set Tipo = @Tipo, Descricao = @Descricao, DataPublicacao = @DataPublicacao," +
                 "ValorImovel = @ValorImovel, ValorEstimadoDocumentacao = @ValorEstimadoDocumentacao, AceitaFinanciamento = @AceitaFinanciamento," +
                 "Observacao = @Observacao, Quarto = @Quarto, Banheiro = @Banheiro, Garagem = @Garagem, AreaUtil = @AreaUtil ,Logadouro = @Logadouro,  Cep = @Cep, Numero = @Numero, Bairro = @Bairro," +
                 "Cidade = @Cidade, UF = @UF where IdImovel = @IdImovel";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue("@IdImovel", imovel.IdImovel);
            cmd.Parameters.AddWithValue("@Tipo", imovel.Tipo);
            cmd.Parameters.AddWithValue("@Descricao", imovel.Descricao);
            cmd.Parameters.AddWithValue("@DataPublicacao", imovel.DataPlubicacao);
            cmd.Parameters.AddWithValue("@ValorImovel", imovel.ValorImovel);
            cmd.Parameters.AddWithValue("@ValorEstimadoDocumentacao", imovel.ValorEstimadoDocumentacao);
            cmd.Parameters.AddWithValue("@AceitaFinanciamento", imovel.AceitaFinanciamento);
            cmd.Parameters.AddWithValue("@Observacao", imovel.Observacao);
            cmd.Parameters.AddWithValue("@Quarto", imovel.Quarto);
            cmd.Parameters.AddWithValue("@Banheiro", imovel.Banheiro);
            cmd.Parameters.AddWithValue("@Garagem", imovel.Garagem);
            cmd.Parameters.AddWithValue("@AreaUtil", imovel.AreaUtil);   
            cmd.Parameters.AddWithValue("@Logadouro", imovel.Logadouro);
            cmd.Parameters.AddWithValue("@Cep", imovel.Cep);
            cmd.Parameters.AddWithValue("@Numero", imovel.Numero);
            cmd.Parameters.AddWithValue("@Bairro", imovel.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", imovel.Cidade);
            cmd.Parameters.AddWithValue("@UF", imovel.UF);

            return await base.ExecuteCommand(cmd);
        }

        public async Task<bool> IncluirAnexoImovel(AnexoImovel anexo)
        {
            string query = "INSERT INTO anexo_imovel_tb (IdImovel, AnexoBase64, ExtensaoArquivo)" +
                "VALUES (@IdImovel, @AnexoBase64, @ExtensaoArquivo)";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"IdImovel", anexo.IdImovel);
            cmd.Parameters.AddWithValue(@"AnexoBase64", anexo.AnexoBase64);
            cmd.Parameters.AddWithValue(@"ExtensaoArquivo", anexo.ExtensaoArquivo);


            var result = await base.ExecuteCommand(cmd);
            return result;
        }

        public async Task<IEnumerable<Imovel>> ObterTodosImovel( )
        {
            string query = "SELECT * FROM  imoveis_tb ";

            var result = await QueryAsync<Imovel>(query);

            return result;
        }

        public async Task<bool> ExcluirAnexoImovel(long idImovel)
        {
            string query = "DELETE  FROM anexo_imovel_tb WHERE IdImovel = " + idImovel;

            var result = await this.ExecuteAsync(query);

            return result;
        }

        public async Task<bool> ExcluirImovel(long idImovel)
        {
            string query = "DELETE  FROM  imoveis_tb WHERE IdImovel = " + idImovel;

            var result = await this.ExecuteAsync(query);

            return result;
        }
        public async Task<IEnumerable<Imovel>> GetImovel(string tipo, decimal valorDe, decimal valorAte, string cidade, string uf)
        {
            string query = $"Select * from imoveis_tb ";

            query += $"where Tipo = '{tipo}' or ValorImovel >= {valorDe.ToString().Replace(",",".")} and ValorImovel <= {valorAte.ToString().Replace(",", ".")} or  Cidade = '{cidade}' or UF = '{uf}' ";

            var result = await base.QueryAsync<Imovel>(query);

            return result;
        }
        public async Task<Imovel> GetById(long id)
        {
            string query = $"select * from imoveis_tb where IdImovel = {id}";

            var result = await base.QueryAsync<Imovel>(query);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<AnexoImovel>> ObterAnexos(long idImovel)
        {
            string query = "select * from anexo_imovel_tb where IdImovel = " + idImovel;

            var result = await base.QueryAsync<AnexoImovel>(query);
            return result;


        }
    }
}
