using Corretora.Imoveis.Core.Repositorys;
using Corretora.Imoveis.Core.Repositorys.Interfaces;
using Corretora.Imoveis.Core.Services;
using Corretora.Imoveis.Core.Services.Interfaces;
using Corretora.Imoveis.WebApp.Applications;
using Corretora.Imoveis.WebApp.Applications.Interfaces;
using System.Data;
using System.Diagnostics;
using Npgsql;
using System.ComponentModel.Design;

namespace Corretora.Imoveis.WebApp.Configuration
{
    public static class InjectDependences
    {
        public static void AddConnection(this IServiceCollection services, ConfigurationManager configuration)
        {
            NpgsqlConnection npgsqlConnection;
            var stringConnection = string.Empty;

            if (Debugger.IsAttached)
                stringConnection = configuration.GetConnectionString("Debug");

            else
                stringConnection = configuration.GetConnectionString("Production");


            npgsqlConnection = new NpgsqlConnection(stringConnection);
            services.AddSingleton<IDbConnection>(npgsqlConnection);
        }

        public static void AddRepositorys(this IServiceCollection services)
        {
            services.AddTransient<IImovelrepository, ImovelRepository>();
            services.AddTransient<IContatoRepository, ContatoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IInserirContatoRepository, InserirContatoRepository>();

        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IImovelService, ImovelService>();
            services.AddTransient<IContatoService, ContatotoService>();
            services.AddTransient<ICepService, CepService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IInserirContatoService, InserirContatoService>();
        }

        public static void AddApplications(this IServiceCollection services)
        {
            services.AddTransient<IImovelApplication, ImovelApplication>();
            services.AddTransient<IContatoApplication, ContatoApplication>();
            services.AddTransient<IUsuarioApplication, UsuarioApplication>();
            services.AddTransient<IInserirContatoApplication, InserirContatoApplication>();
        }
    }
}
