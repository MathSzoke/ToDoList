using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Infra.Data.EntitiesConfig;

namespace Infra.Data.Contexts;

/// <summary>
/// Contexto do banco de dados para gerenciar as interações com as entidades relacionadas a listas de tarefas.
/// </summary>
public class ToDoListDbContext : DbContext
{
    /// <summary>
    /// Construtor padrão sem parâmetros para o contexto do banco de dados.
    /// </summary>
    public ToDoListDbContext() { }

    /// <summary>
    /// Construtor que aceita opções de configuração para o contexto do banco de dados.
    /// </summary>
    /// <param name="options">Opções de configuração do DbContext.</param>
    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options) { }

    /// <summary>
    /// Define uma coleção de entidades do tipo ToDoListEntity no contexto do banco de dados.
    /// </summary>
    public virtual DbSet<ToDoListEntity> ToDoList { get; set; }

    /// <summary>
    /// Configurações de inicialização para o contexto do banco de dados.
    /// </summary>
    /// <param name="ob">Opções do construtor de contexto do banco de dados.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder ob)
    {
        if (!ob.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            ob.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }

    /// <summary>
    /// Configurações de modelagem para o contexto do banco de dados.
    /// </summary>
    /// <param name="builder">Construtor de modelos para o contexto do banco de dados.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Define o esquema padrão para o contexto do banco de dados como "DevDotNetTRENDX".
        builder.HasDefaultSchema("DevDotNetTRENDX");

        // Aplica as configurações específicas da entidade ToDoListEntity ao modelo.
        builder.ApplyConfiguration(new ToDoListConfig());

        base.OnModelCreating(builder);
    }
}
