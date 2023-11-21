using Filmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes.Infrastructure.Data.Configurations
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            
            builder.ToTable("Filme");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).HasMaxLength(200).IsRequired();
            builder.Property(u => u.Active).IsRequired();

            // Configuração do relacionamento entre Filme e Genero
            builder.HasOne(u => u.Genero)
                .WithMany(p => p.Filmes)
                .HasForeignKey(p => p.IdGenero);
        }
    }
}
