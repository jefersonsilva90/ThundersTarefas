using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThunderTarefas.Domain.Entities;

namespace ThunderTarefas.Data.EntitiesConfiguration
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnType("uuid");
           
            builder.Property(p => p.Titulo).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(250).IsRequired().HasColumnType("text");
            builder.Property(p => p.PrazoConclusao).IsRequired();
            builder.Property(p => p.DataConclusao).IsRequired(false);
            builder.Property(p => p.Concluida).IsRequired();
        }
    }
}
