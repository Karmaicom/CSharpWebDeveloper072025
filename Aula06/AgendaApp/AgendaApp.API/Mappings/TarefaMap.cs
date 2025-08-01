using AgendaApp.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApp.API.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("tarefa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Prioridade)
                .HasColumnName("prioridade")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.CategoriaId)
                .HasColumnName("categoria_id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Tarefas)
                .HasForeignKey(x => x.CategoriaId);

        }
    }
}
