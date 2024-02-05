using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Data.EntitiesConfig.Utils;

/// <summary>
/// Extensão para configuração de índices usando o Entity Framework.
/// </summary>
public static class FluentIndexExtension
{
    /// <summary>
    /// Cria um índice para a configuração de uma entidade no Entity Framework.
    /// </summary>
    /// <typeparam name="T">Tipo da entidade.</typeparam>
    /// <param name="entityType">Configuração da entidade no Entity Framework.</param>
    /// <param name="indexName">Nome desejado para o índice.</param>
    /// <param name="properties">Lista de colunas que compõem o índice.</param>
    /// <param name="isClustered">Determina se o índice é agrupado (clustered) ou não.</param>
    /// <exception cref="Exception">Disparada se as propriedades ou o nome do índice forem inválidos.</exception>
    public static void CreateIndex<T>(this EntityTypeConfiguration<T> entityType, string indexName, PrimitivePropertyConfiguration[] properties, bool isClustered = false)
        where T : class, new()
    {
        // Verifica se há propriedades para o índice
        if (!(properties.Length != 0))
            throw new Exception("Propriedades inválidas para o índice");

        // Garante que a configuração da entidade não seja nula
        ArgumentNullException.ThrowIfNull(entityType);

        // Verifica se o nome do índice é válido
        if (string.IsNullOrEmpty(indexName))
            throw new Exception("Nome do índice inválido");

        // Garante que a lista de propriedades não seja nula
        ArgumentNullException.ThrowIfNull(properties);

        // Parte do índice usado para identificar cada coluna
        var partIndex = 1;

        // Itera sobre as propriedades para adicionar a configuração do índice
        foreach (var property in properties)
        {
            // Adiciona a anotação "Index" com as informações do índice para a coluna
            property.HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute(indexName, partIndex) { IsClustered = isClustered }));
            partIndex++;
        }
    }
}
