using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.EntitiesConfig.Utils;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.EntitiesConfig;

/// <inheritdoc />
internal class ToDoListConfig : EntityTypeConfiguration<ToDoListEntity>, IEntityTypeConfiguration<ToDoListEntity>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<ToDoListEntity> builder)
    {
        // Configuração da chave primária
        builder.HasKey(x => x.ID);

        // Configuração da propriedade Title
        builder.Property(t => t.Title)
            .HasColumnName("Title")
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        // Configuração da propriedade Description
        builder.Property(d => d.Description)
            .HasColumnName("Description")
            .HasColumnType("nvarchar(4000)")
            .HasMaxLength(4000)
            .IsRequired();

        // Configuração da propriedade IsCompleted
        builder.Property(c => c.IsCompleted)
            .HasColumnName("IsCompleted")
            .HasColumnType("bit")
            .IsRequired();

        // Configuração do nome da tabela
        builder.ToTable("ToDoList");

        // Configuração do índice da chave ID
        this.CreateIndex("IX_ToDoList_ID", [this.Property(x => x.ID)]);
    }
}
